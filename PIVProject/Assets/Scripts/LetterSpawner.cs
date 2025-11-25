using UnityEngine;

public class LetterSpawner : MonoBehaviour
{

    public GameObject letter;
    public int objectCount = 2;
    public float spawnRadius = 30f;
    public float spawnCollisionCheckRadius;
    public GameObject findLetter;
    public GameObject findCrucifix;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnLetter();
    }

    // Update is called once per frame
    void Update()
    {
        findLetter = GameObject.Find("LetterEmpty(Clone)");
        findCrucifix = GameObject.Find("Rotation");
        if(findLetter == null && findCrucifix == null)
        {
            SpawnLetter();
        }
    }

    private void SpawnLetter()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-30, 0), 1f, Random.Range(-30, 0));
        //Instantiate(letter, spawnPoint, Quaternion.identity);
        //Debug.Log("Letter Spawned");
        if(!Physics.CheckSphere(spawnPoint, spawnCollisionCheckRadius))
        {
            Instantiate(letter, spawnPoint, Quaternion.identity);
            Debug.Log("Letter Spawned");
        }
    }
}
