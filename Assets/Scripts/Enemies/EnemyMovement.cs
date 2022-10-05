using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyStatsSo stats;
        private float gravityValue = -9.81f;

        [SerializeField] private GameObject player;
        private bool dangerZone;
        private CharacterController controller;
        private Vector3 playerVelocity;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            player = GameObject.Find("Player");
        }

        private void Update()
        {
            Look();
            Move();
        }

        void Move()
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
            
            Vector3 direction = player.transform.position - transform.position;
            Vector3 velocity = direction * stats.speed / 10;
            
            if (!dangerZone)
            {
                controller.Move(velocity * Time.deltaTime);

            }
            else
            {
                controller.Move(velocity * (-1 * Time.deltaTime));
            }
        }

        void Look()
        {
            transform.LookAt(player.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y ,0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                dangerZone = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                dangerZone = false;
            }
        }
    }
