using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishZone : MonoBehaviour
{
    [SerializeField] private WinUI _winUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        EndGame();
    }
    private void EndGame()
    {
        _winUI.ShowWinPanel();
    }
}
