using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameOverScreen gameOverDead;
    public GameOverScreen gameOverWin;
    public static UIManager instance;
    public TMP_Text pageText;
    public TMP_Text healthText;
    public GameObject escapeText;

    int pageCount = 0;
    int maxPageCount = 8;
    int health;
    int maxHealth = 10;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        health = maxHealth;
        healthText.text = "Health: " + health.ToString();
        pageText.text = "Pages: " + pageCount.ToString() + "/8";
        pageCount = 0;
    }

    public void AddPage()
    {
        pageCount += 1;
        pageText.text = "Pages: " + pageCount.ToString() + "/8";
        Debug.Log("Page amount:" + pageCount);
    }

    public void PageCheck()
    {
        if(pageCount == maxPageCount)
        {
            escapeText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameOverWin.SetUp();
            }
        }
    }

    public void PlayerTakeDamage(int amount)
    {
        health -= amount;
        healthText.text = "Health: " + health.ToString();
        
        if(health <= 0)
        {
            gameOverDead.SetUp();
        }
    }
}
