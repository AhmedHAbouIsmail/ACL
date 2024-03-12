using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
    GameObject temp;

    public void SpawnTile(bool spawnItems)
    {
        temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacles(0.5f);
            temp.GetComponent<GroundTile>().SpawnObstacles(4.5f);
            temp.GetComponent<GroundTile>().SpawnCollectables();
            temp.GetComponent<GroundTile>().SpawnHealth();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
                SpawnTile(false);
            else
                SpawnTile(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
