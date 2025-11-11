using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool checkPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && checkPlayer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            checkPlayer = true;
        }
    }
}
