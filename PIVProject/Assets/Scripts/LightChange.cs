using Unity.VisualScripting;
using UnityEngine;

public class LightChange : MonoBehaviour
{

    private Transform player;

    public float distanceToLight;
    public float minDistance = 0.1f;
    public float maxDistance = 30f;
    public float maxIntesity = 300f;
    public Light lightIntensity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lightIntensity.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIntensity();
    }

    private void ChangeIntensity()
    {
        distanceToLight = Vector3.Distance(transform.position, player.position);
        distanceToLight = Mathf.Clamp(distanceToLight, minDistance, maxDistance);
        distanceToLight = (distanceToLight - minDistance) / (maxDistance - minDistance);
        distanceToLight = 1 - distanceToLight; 

        lightIntensity.intensity = maxIntesity * distanceToLight;
    }
}
