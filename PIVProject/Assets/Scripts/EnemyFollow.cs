using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    private Transform player;
    private float speed = 3.5f;
    private float range = 100f;
    private float distance;
    public Material ghostMaterial;
    public int health, maxHealth = 2;
    public int damage = 1;
    public float magnitude = 500f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = maxHealth;
    }
    
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
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            UIManager.instance.PlayerTakeDamage(damage);
            Debug.Log("Player is damaged");
        }

        else if(collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 forceDirection = transform.position - bullet.transform.position;
            forceDirection.Normalize();
            rb.AddForce(forceDirection * magnitude);
            Debug.Log("Force is applied");
        }
    }
}
