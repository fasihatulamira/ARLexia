using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class ARSessionManager : MonoBehaviour
{
    public ARSession arSession;

    private void Awake()
    {
        // Ensure the AR session persists across scene changes
        DontDestroyOnLoad(arSession.gameObject);
    }

    private void OnEnable()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the scene loaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Resume the AR session when the "Belajar" scene is loaded
        if (scene.name == "Belajar")
        {
            arSession.enabled = true;
            arSession.Reset();
        }
    }
}