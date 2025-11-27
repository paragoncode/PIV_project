using UnityEngine;

public class PageTotalCheck : MonoBehaviour
{
    public UIManager checkPage;
    bool checkPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && checkPlayer)
        {
            checkPage.PageCheck();
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
