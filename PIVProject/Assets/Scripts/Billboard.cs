using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    void LateUpdate()
    {
        transform.LookAt(cam.transform);

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y - 180f, 0f);
    }
}