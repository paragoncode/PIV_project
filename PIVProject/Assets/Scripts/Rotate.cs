using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationPerMin = 5f;
    void Update()
    {
        transform.Rotate(0f, 6f * rotationPerMin * Time.deltaTime, 0f);
    }
}
