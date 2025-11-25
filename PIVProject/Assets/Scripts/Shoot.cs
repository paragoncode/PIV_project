using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float velocity = 700f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject sphere = Instantiate(bullet, transform.position, transform.rotation);
            sphere.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, velocity, 0));
        }
    }
}
