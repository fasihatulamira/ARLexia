using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCleanup : MonoBehaviour
{
    void OnDestroy()
    {
        Belajar.selectedSprite = null;
    }
}