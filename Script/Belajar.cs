using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Belajar : MonoBehaviour
{
    public static Sprite selectedSprite; // Static variable to hold the selected sprite

    // Dictionary to map image target names to their corresponding sprites
    public Dictionary<string, Sprite> imageTargetToSpriteMap = new Dictionary<string, Sprite>
    {
        { "ImageTargetDadu", null }, // Assign the sprite for 'B' in the Unity Inspector
        { "ImageTargetHati", null }, // Assign the sprite for 'H' in the Unity Inspector
        { "ImageTargetGuli", null },
        { "ImageTargetJari", null },
        { "ImageTargetBola", null },
        // Add more image targets here
    };

    public List<Button> backButtons; // List of back buttons in the Belajar scene
    public GameObject imageScan; // Reference to the ImageScan GameObject
    public GameObject panelMenu; // Reference to the PanelMenu GameObject

    private bool isImageTargetDetected = false; // Flag to track if any image target is detected

    void Start()
    {
        // Initially hide the panelMenu and show the imageScan
        if (imageScan != null) imageScan.SetActive(true);
        if (panelMenu != null) panelMenu.SetActive(false);

        // Subscribe to the ARTrackedImageManager's tracked images changed event
        ARTrackedImageManager arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        if (arTrackedImageManager != null)
        {
            arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
        else
        {
            Debug.LogError("ARTrackedImageManager not found in the scene.");
        }
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            Debug.Log("Image target detected: " + trackedImage.referenceImage.name);
            OnImageTargetDetected(trackedImage.referenceImage.name);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            Debug.Log("Image target updated: " + trackedImage.referenceImage.name);
            OnImageTargetDetected(trackedImage.referenceImage.name);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            Debug.Log("Image target removed: " + trackedImage.referenceImage.name);
            // Optionally handle the removal of image targets if needed
        }
    }

    public void OnImageTargetDetected(string imageTargetName)
    {
        if (imageTargetToSpriteMap.ContainsKey(imageTargetName))
        {
            selectedSprite = imageTargetToSpriteMap[imageTargetName];
            isImageTargetDetected = true;
            UpdateUI();
        }
        else
        {
            Debug.LogError("Unknown image target detected: " + imageTargetName);
        }
    }

    private void UpdateUI()
    {
        if (isImageTargetDetected)
        {
            // Hide the imageScan and show the panelMenu
            if (imageScan != null)
            {
                imageScan.SetActive(false);
                Debug.Log("ImageScan hidden.");
            }
            if (panelMenu != null)
            {
                panelMenu.SetActive(true);
                Debug.Log("PanelMenu shown.");
            }
        }
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}