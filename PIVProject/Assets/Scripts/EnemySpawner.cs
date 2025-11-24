using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyPrefab;

    public float minSpawnTime = 5f;

    public float maxSpawnTime = 10f;

    private float timeUntilSpawn;

    public float spawnRadius = 5f;
    public GameObject findCrucifix;
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        findCrucifix = GameObject.Find("Rotation");
        timeUntilSpawn -= Time.deltaTime;
        
        if (findCrucifix == null && timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = (Vector3)gameObject.transform.position + spawnOffset;
        Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
