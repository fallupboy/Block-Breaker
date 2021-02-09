using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    // Configs
    [SerializeField] AudioClip[] myAudioClips;

    // Cached references
    AudioSource currentAudioSource;
    Scene currentScene;


    // States
    bool isPlaying = false;
    int currentSceneIndexHolder;

    private void Awake()
    {
        int audioStatusCount = FindObjectsOfType<Audio>().Length;
        if (audioStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentAudioSource = GetComponent<AudioSource>();
        currentSceneIndexHolder = currentScene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Start Menu")
        {
            CompareSceneIndexe();
            currentAudioSource.clip = myAudioClips[0];
            CheckAudioSource();
        }
        else if (currentScene.name == "Game Over")
        {
            CompareSceneIndexe();
            currentAudioSource.clip = myAudioClips[2];
            CheckAudioSource();
        }
        else if (currentScene.name == "End Scene")
        {
            CompareSceneIndexe();
            currentAudioSource.clip = myAudioClips[3];
            CheckAudioSource();
        }
        else if (currentScene.buildIndex == 2)
        {
            CompareSceneIndexe();
            currentAudioSource.clip = myAudioClips[1];
            CheckAudioSource();
        }
    }

    private void CheckAudioSource()
    {
        if (!isPlaying)
        {
            currentAudioSource.Play();
            isPlaying = true;
        }
    }

    private void CompareSceneIndexe()
    {
        if (currentSceneIndexHolder != currentScene.buildIndex)
        {
            isPlaying = false;
            currentSceneIndexHolder = currentScene.buildIndex;
        }
    }
}
