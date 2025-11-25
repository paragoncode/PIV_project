using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool checkPlayer;

    public GameObject pickUpText;

    public GameObject objectOnPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickUpText.SetActive(false);
        objectOnPlayer = GameObject.Find("First person player/Main Camera/Crucifix14");
        objectOnPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        objectOnPlayer = GameObject.Find("First person player/Main Camera/Crucifix14");
        if(Input.GetKeyDown(KeyCode.E) && checkPlayer)
        {
            Destroy(gameObject);
            pickUpText.SetActive(false);
            objectOnPlayer.SetActive(true);
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
            pickUpText.SetActive(false);
        }
    }
}
