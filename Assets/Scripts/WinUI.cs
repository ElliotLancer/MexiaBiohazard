using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;

    public void ShowWinPanel()
    {
        Time.timeScale = 0f;
        _winPanel.SetActive(true);
    }

    public void ToNextLevel()
    {
        Time.timeScale = 1f;
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentLevelIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene(currentLevelIndex + 1);
        }
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
