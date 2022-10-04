using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    public float currentFrame;
    [SerializeField] public float maxFrames;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSomoothing = 1000f;
    [SerializeField] private float smoothInputSpeed = .2f;
    [SerializeField] private Rigidbody playerBody;
    public float dashSpeed;
    public float dashTime;

    [SerializeField] private bool isGamepad;


    private CharacterController controller;

    private Vector2 smoothInputVelocity;
    private Vector2 currentInputVector;
    private Vector2 movement;
    private Vector2 aim;
    private Vector3 playerVelocity;

    private PlayerControls playerControls;
    private PlayerInput playerInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();

        playerControls.Controls.Shotgun.performed += ctx => HandleShotgunInput();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
        HandleShootInput();
        HandleDash();
    }
    void HandleInput()
    { 
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();
    }
    void HandleMovement()
    {
        {
            currentInputVector = Vector2.SmoothDamp(currentInputVector, movement, ref smoothInputVelocity, smoothInputSpeed);

            Vector3 move = new Vector3(currentInputVector.x, 0, currentInputVector.y);
            controller.Move(move * Time.deltaTime * playerSpeed);
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
    void HandleRotation()
    {
        if (isGamepad)
        {
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newrotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newrotation, gamepadRotateSomoothing * Time.deltaTime);
                }
            }
        }
        else
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit))
            {
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }
    }

    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void OnDeviceChange (PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    void HandleShootInput()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerGun.Instance.Shoot();
        }
    }
    void HandleShotgunInput()
    
    {
            Shotgun.Instance.ShotgunShoot();
    }
    void HandleDash()
    {
        playerControls.Controls.Dash.performed += ctx => Dash();

        void Dash()
        {
            StartCoroutine(DashMove());
            DashImmortality();
        }

        IEnumerator DashMove()
        {
            float startTime = Time.time;

            while (Time.time < startTime + dashTime)
            {
                transform.Translate(Vector3.forward * dashSpeed);

                yield return null;
            }
        }
    }
    public void DashImmortality()
    {
        Debug.Log("Immortal");
        currentFrame = maxFrames;
        playerHealth.mortal = false;

        if (currentFrame <= 0)
        {
            currentFrame = 0;
            playerHealth.mortal = true;
            Debug.Log("NotImmortal");
        }
    }
}

