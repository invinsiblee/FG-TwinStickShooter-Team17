using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSpawner : MonoBehaviour
{
    public GameObject[] spawnGameObject; // The variable for the chosen object or objects to spawn.
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    int randomObject;

    private void Start()
    {
        StartCoroutine(waitSpawner());
    }


        void Update()
        {
                                                                    //if(Input.GetKeyDown(KeyCode.Space)) // When spacekey is pressed spawn items
             spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

            // Takes and cycles through the random indexes of the items in the array.
            int randimIndex = Random.Range(0, spawnGameObject.Length);

            // Randomises the spawn position with the x/y/z axis also horizontially and vertically.
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-85, 85), 5, Random.Range(-87, 87));

            // Instansiates the spawnning of the game objects and the randomSpawnPosition
            Instantiate(spawnGameObject[randimIndex], randomSpawnPosition, Quaternion.identity);
        
            
           
         }

            IEnumerator waitSpawner()
            {
                yield return new WaitForSeconds(startWait);

                while (!stop)
                {
                   
                    yield return new WaitForSeconds(spawnWait);
                }
            }
}
