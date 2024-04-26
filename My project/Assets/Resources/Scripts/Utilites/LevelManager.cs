using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        UIEvents.toggleLosePanel?.Invoke(false);
        SceneManager.LoadScene(currentSceneName);
    }
}