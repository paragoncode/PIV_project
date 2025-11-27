using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 5f;
    void Update()
    {
        transform.Rotate(0f, 6f * rotationSpeed * Time.deltaTime, 0f);
    }
}
