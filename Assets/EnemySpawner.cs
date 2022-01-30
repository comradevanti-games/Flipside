using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Transform spawnCenter;
    [SerializeField] private float offset = 10.0f;
    [SerializeField] [Range(1, 10)] private float spawnRate;
    [SerializeField] private List<GameObject> enemyPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandom", spawnRate, spawnRate);
    }

    void SpawnRandom()
    {
        Vector3 curPos = spawnCenter.position;
        float x = Random.Range(curPos.x, curPos.x + offset) + offset;
        float y = Random.Range(curPos.y, curPos.y + offset) + offset;
        float z = Random.Range(curPos.z, curPos.z + offset) + offset;

        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], new Vector3(x, y, z), Quaternion.identity);
    }
}
