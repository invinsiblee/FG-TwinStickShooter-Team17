using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject cubeprefab; // The variable for the chosen object to spawn.

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-85, 85), 5, Random.Range(-87, 87)); // Randomises the spawn position with the x/y/z axis also horizontially and vertically.
            Instantiate(cubeprefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
