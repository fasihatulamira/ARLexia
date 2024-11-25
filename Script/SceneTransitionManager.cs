using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Belajar")
        {
            // Perform any necessary cleanup or state resets
            Debug.Log("Belajar scene loaded. Performing cleanup.");
            // Example: Reset static variables, clear lists, etc.
            Belajar.selectedSprite = null;
            // Add any other necessary cleanup code here
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}