using UnityEngine;

public class EnableObjet : MonoBehaviour
{

    public GameObject objectOnPlayer;
    private bool checkPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectOnPlayer = GameObject.Find("First person player/Main Camera/Crucifix14");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && checkPlayer)
        {
            objectOnPlayer.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            checkPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            checkPlayer = false;
        }
    }
}
