using UnityEngine;

public class DontDestroyOnLoadManager : MonoBehaviour
{
    // Singleton instance
    private static DontDestroyOnLoadManager instance;

    // Reference to the GameObjects you want to persist
    public GameObject image;
    public GameObject backButton;
    public GameObject deleteButton;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set the instance to this
            instance = this;

            // Mark the GameObjects to not be destroyed when loading a new scene
            DontDestroyOnLoad(image);
            DontDestroyOnLoad(backButton);
            DontDestroyOnLoad(deleteButton);
        }
        else
        {
            // If an instance already exists, destroy this instance
            Destroy(gameObject);
        }
    }
}