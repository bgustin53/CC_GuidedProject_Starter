using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("Enter the names of each scene in order to load.")]
    [SerializeField] private string[] sceneName; // The names of the scenes to load in order

    [Tooltip("Enter time between scenes.")]
    [SerializeField] private float delayInSeconds = 2f; // Delay in seconds before loading the scene
    private int sceneToLoad;

    private void Awake()
    {
        Invoke("LoadScene", delayInSeconds); // Invoke the LoadScene method after the specified delay
    }

    private void LoadScene()
    {
        if (sceneToLoad < sceneName.Length)
        {
            SceneManager.LoadScene(sceneName[sceneToLoad]); // Load the scene by its name
        }
    }
}