using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    private Transform player;

    private float speed = 3.5f;
    private float range = 100f;
    private float distance;

    public Material ghostMaterial;

    public float health, maxHealth = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = maxHealth;
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
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
        } 
    }
}
