using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void SetUp()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game"); 
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
