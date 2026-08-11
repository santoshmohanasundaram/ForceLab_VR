using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PersistentSceneSwitcher : MonoBehaviour
{
    public static PersistentSceneSwitcher instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Detect screen tap or mouse click using New Input System
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        int nextIndex = (currentIndex + 1) % totalScenes;

        SceneManager.LoadScene(nextIndex);
    }
}
