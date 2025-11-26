using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool checkPlayer;

    public GameObject pickUpText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickUpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PickUpPage();
    }

    private void PickUpPage()
    {
        if(Input.GetKeyDown(KeyCode.E) && checkPlayer)
        {
            UIManager.instance.AddPage();
            Destroy(gameObject);
            pickUpText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            checkPlayer = true;
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            checkPlayer = false;
            pickUpText.SetActive(false);
        }
    }
}
