using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstacle1Prefab;
    [SerializeField] GameObject obstacle2Prefab;
    [SerializeField] GameObject obstacle3Prefab;
    [SerializeField] GameObject collectablePrefab;
    [SerializeField] Material[] colors;
    [SerializeField] Material color;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacles(float pos)
    {
        int obstacleSpawnIndex = Random.Range(2, 7);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        int size = Random.Range(1, 4);
        if (size == 3 && obstacleSpawnIndex == 4)
            Instantiate(obstacle3Prefab, spawnPoint.position, Quaternion.identity, transform);
        else if (size == 2 && (obstacleSpawnIndex == 3 || obstacleSpawnIndex==6))
            Instantiate(obstacle2Prefab, spawnPoint.position, Quaternion.identity, transform);
        else
        {
            while(obstacleSpawnIndex!=2 && obstacleSpawnIndex != 4 && obstacleSpawnIndex != 5)
                obstacleSpawnIndex = Random.Range(2, 7);
            spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
            Vector3 temp = spawnPoint.position;
            temp.y = pos;
            Instantiate(obstacle1Prefab, temp, Quaternion.identity, transform);
        }
    }

    public void SpawnCollectables()
    {
        int collectN = 3;
        int plane;
        for(int i = 0; i < collectN; i++)
        {
            GameObject temp = Instantiate(collectablePrefab);
            temp.GetComponent<MeshRenderer>().material = colors[Random.Range(0,3)];
            plane = Random.Range(1, 3);
            if (plane == 1)
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>(), 0.5f);
            else
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>(), 4.5f);
        }
        
    }

    public void SpawnHealth()
    {
        int collectN = 1;
        int plane;
        for (int i = 0; i < collectN; i++)
        {
            GameObject temp = Instantiate(collectablePrefab);
            temp.GetComponent<MeshRenderer>().material = color;
            plane = Random.Range(1, 3);
            if(plane==1)
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>(),0.5f);
            else
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>(), 4.5f);
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider, float posY)
    {
        int rand = Random.Range(1,4);
        float posX;
        if (rand == 1)
            posX = 3.33f;
        else if (rand == 2)
            posX = 0;
        else
            posX = -3.33f;
        Vector3 point = new Vector3(posX, posY, Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
            point = GetRandomPointInCollider(collider, posY);
        return point;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
