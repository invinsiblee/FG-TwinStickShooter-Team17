using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("CREATE EMPTY GAME OBJECT WITH ONE")]
    [Header("TRIGGER BOX COLLIDER AS CHILDREN")]
    [Space(15)]
    public GameObject spawnItem;

    // Store childrens colliders

    [ContextMenuItem("Collect Colliders", "GetColliders", order = 4)]
    [SerializeField] List<Collider> collidersBase ;
    [SerializeField] List<float> colliderArea = new List<float>();

    [SerializeField] LayerMask hitOnly;

    
    [ContextMenu("Gather Colliders")]

    

    void GetColliders()
    {
        collidersBase = GetComponentsInChildren<Collider>().ToList<Collider>();
    }

    #region Vector3 collider areas 
    Vector3 spawnPoint;
    #endregion

    // The total area the colliders covers, relative to the (X,Z)-Axis
    float spawnTotalArea;

    void Awake()
    {
        if (collidersBase.Count < 1)
        {
            collidersBase = GetComponentsInChildren<Collider>().ToList<Collider>();
        }

        OutputData();
    }

    private void OutputData()
    {

        spawnTotalArea = 0;
        foreach(var collider in collidersBase)
        {
            float size = 0;
            switch (collider)
            {
                case BoxCollider:
                    size = collider.bounds.size.x * collider.bounds.size.z;
                    break;
                case SphereCollider:
                    SphereCollider col = collider as SphereCollider;
                    size = Mathf.Pow(col.radius * CompareLocalScale(col.transform.localScale), 2f) * Mathf.PI;
                    break;
                default:
                    break;
            }
 
            spawnTotalArea += size;
            colliderArea.Add(size);
            Debug.Log(size);
        }
        Debug.LogAssertion(spawnTotalArea);

        
        //StartCoroutine(Poop());
        
    }

    // Debug below
    IEnumerator Poop()
    {
        int i = 0;
        while(i < 1000)
        {
            Spawn(spawnItem);
            i++;
            yield return new WaitForEndOfFrame();
            
        }

    }

    float CompareLocalScale(Vector3 localScale)
    {
        float x = Mathf.Abs(localScale.x);
        float y = Mathf.Abs(localScale.y);
        float z = Mathf.Abs(localScale.z);
        if (x >= y && x >= z)
        {
            return x;
        } else if (y >= x && y >= z) 
        {
            return y;
        } else
        {
            return z;
        }
    }
    
    public void Spawn(GameObject spawnObject)
    {
        float random = UnityEngine.Random.Range(0, spawnTotalArea);
        float collect = 0;
        Collider col = null;
        for (int i = 0; i < colliderArea.Count; i++)
        {
            float size = colliderArea[i];
            collect += size;
            if (collect >= random)
            {
                col = collidersBase[i];
                break;
            }

        }
        
        switch (col)
        {
            case BoxCollider:
                 spawnPoint = new Vector3(UnityEngine.Random.Range(-col.bounds.size.x, col.bounds.size.z) / 2 , 0f, UnityEngine.Random.Range(-col.bounds.size.z, col.bounds.size.z) / 2) + col.bounds.center;

                break;

            case SphereCollider:
                SphereCollider collider = (SphereCollider)col;
                spawnPoint = UnityEngine.Random.Range(0f, collider.radius *  CompareLocalScale(col.transform.localScale)) * new Vector3(UnityEngine.Random.Range(-10f, 10f), 0f, UnityEngine.Random.Range(-10f, 10f)).normalized + col.bounds.center;

                break;
            default:
                break;
        }
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint, Vector3.down, out hit, Mathf.Infinity, hitOnly))
        {
            Instantiate(spawnObject, hit.point, Quaternion.identity);

        }
    }
    /*
     void Spawn(GameObject spawnObject)
    {
        float random = UnityEngine.Random.Range(0, spawnTotalArea);
        float collect = 0;
        Collider col = null;
        for (int i = 0; i < colliders.Length; i++)
        {
            float size = colliders[i].bounds.size.x * colliders[i].bounds.size.z;
            collect += size;
            if (collect >= random)
            {
                col = colliders[i];
                Debug.Log(i);
                break;
            }

        }
        spawnPoint = new Vector3(UnityEngine.Random.Range(col.bounds.min.x, col.bounds.max.x), 1f, UnityEngine.Random.Range(col.bounds.min.z, col.bounds.max.z));
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint, Vector3.down, out hit, Mathf.Infinity))
        {
            Instantiate(spawnObject, hit.point, Quaternion.identity);

        }
    }*/

}
