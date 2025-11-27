using UnityEngine;

public class PageTotalCheck : MonoBehaviour
{
    public UIManager checkPage;
    public GameObject escapeText;
    bool checkPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        escapeText.SetActive(false);
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
            checkPage.PageCheck();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            checkPlayer = false;
            escapeText.SetActive(false);
        }
    }
}
