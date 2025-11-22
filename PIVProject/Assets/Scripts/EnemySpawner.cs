using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyPrefab;

    public float minSpawnTime = 5f;

    public float maxSpawnTime = 10f;

    private float timeUntilSpawn;


    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        
        if (timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, gameObject.transform.position, Quaternion.identity);
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
