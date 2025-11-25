using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float counter = 5f;

    void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyFollow>(out EnemyFollow enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
