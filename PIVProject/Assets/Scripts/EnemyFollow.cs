using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    private Transform player;

    private float speed = 2f;
    public float range = 30f;
    private float distance;

    public Material ghostMaterial;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (distance <= range)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.LookAt(player.position);
            ghostMaterial.color = Color.red;
        }
        else if (distance > range)
        {
            ghostMaterial.color = Color.white;
        }
    }
}
