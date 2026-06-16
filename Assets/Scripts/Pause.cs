using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private void Start()
    {
        _pausePanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowPausePanel();
        }
    }
    public void ShowPausePanel()
    {
        bool isActive = !_pausePanel.activeSelf;
        _pausePanel.SetActive(isActive);

        Time.timeScale = isActive ? 0f : 1f;
    }
    public void ToMainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("exited the game");
    }
}
