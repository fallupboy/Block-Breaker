using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Slider ballSpeed;
    [SerializeField] Toggle autoPlay;
    [SerializeField] TextMeshProUGUI currBallSpeed;

    // States variables
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Cached references
    Scene activeScene;
    AudioSource myAudioSource;
    GameSession gameSession;

     
    private void Awake()
    {
        int pauseMenuStatusCount = FindObjectsOfType<PauseMenu>().Length;
        if (pauseMenuStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    

    // Start is called only once
    private void Start()
    {
        myAudioSource = FindObjectOfType<Audio>().GetComponent<AudioSource>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    private void Update()
    {
        currBallSpeed.text = ballSpeed.value.ToString("0.0");
        activeScene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckPauseMenu();
        }

        if (Time.timeScale != 0)
        {
            Time.timeScale = ballSpeed.value;
        }

        if (autoPlay.isOn)
        {
            gameSession.isAutoPlayEnabled = true;
        }
        else
        {
            gameSession.isAutoPlayEnabled = false;
        }

        if (activeScene.name == "Start Menu" || activeScene.name == "Rules Menu" || activeScene.name == "End Scene")
        {
            Destroy(gameObject);
        }
    }

    public void CheckPauseMenu()
    {
        
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        myAudioSource.volume = 1.0f;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseButton.gameObject.SetActive(true);
    }

    public void Pause()
    {
        myAudioSource.volume = 0.2f;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseButton.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        myAudioSource.volume = 1f;
        Time.timeScale = 1f;
        FindObjectOfType<GameSession>().ResetGame();
        FindObjectOfType<SceneLoader>().LoadMenuScene();
    }

    public void ResetPauseMenu()
    {
        Destroy(gameObject);
    }
}
