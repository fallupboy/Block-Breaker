using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPauseScene()
    {
        SceneManager.LoadScene("Pause");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadStartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else if (SceneManager.GetActiveScene().name == "Game Over")
        {
            FindObjectOfType<PauseMenu>().ResetPauseMenu();
            SceneManager.LoadScene(2);
        }
        else
        {
            FindObjectOfType<GameSession>().ResetGame();
            SceneManager.LoadScene(2);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
