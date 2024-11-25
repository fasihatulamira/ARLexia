using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TraceNavigate : MonoBehaviour
{
    public GameObject image;
    public GameObject buttonBack;
    public GameObject ARTrace;
    public GameObject Script;
    public GameObject buttonDelete;
    public GameObject videoOverlay; // Reference to the video overlay GameObject
    public GameObject backButtonToMainMenu; // Reference to the back button to the main menu
    public GameObject backButtonToMainMenu2;
    private ARDrawOnPlane arDrawOnPlane;
    public GameObject imageScan; // Reference to the ImageScan GameObject

    void Start()
    {

        if (imageScan != null) imageScan.SetActive(true);

        // Get the ARDrawOnPlane component from the Script GameObject
        if (Script != null)
        {
            arDrawOnPlane = Script.GetComponent<ARDrawOnPlane>();
        }


        // Set the image based on the selected sprite from the Belajar scene
        if (Belajar.selectedSprite != null)
        {
            SetImage(Belajar.selectedSprite);
        }
        else
        {
            Debug.LogError("No sprite selected in Belajar scene.");
        }
    }

    public void Trace()
    {
        // Disable the video overlay
        if (videoOverlay != null)
        {
            videoOverlay.SetActive(false);
        }

        // Hide the imageScan
        if (imageScan != null)
        {
            imageScan.SetActive(false);
            Debug.Log("ImageScan hidden.");
       }

        // Enable trace functionality
        if (image != null) image.SetActive(true);
        if (buttonBack != null) buttonBack.SetActive(true);
        if (ARTrace != null) ARTrace.SetActive(true);
        if (Script != null) Script.GetComponent<ARDrawOnPlane>().enabled = true;
        if (buttonDelete != null) buttonDelete.SetActive(true);

        // Disable the back button to the main menu
        if (backButtonToMainMenu != null)
        {
            backButtonToMainMenu.SetActive(false);
        }

        // Disable the back button to the main menu
        if (backButtonToMainMenu2 != null)
        {
            backButtonToMainMenu2.SetActive(false);
        }
    }

    public void TraceOff()
    {
        // Disable trace functionality
        if (image != null) image.SetActive(true);
        if (buttonBack != null) buttonBack.SetActive(true);
        if (ARTrace != null) ARTrace.SetActive(true);
        if (Script != null) Script.GetComponent<ARDrawOnPlane>().enabled = true;
        if (buttonDelete != null) buttonDelete.SetActive(true);

        // Re-enable the video overlay
        if (videoOverlay != null)
        {
            videoOverlay.SetActive(true);
        }

        // Re-enable the back button to the main menu
        if (backButtonToMainMenu != null)
        {
            backButtonToMainMenu.SetActive(true);
        }

        // Re-enable the back button to the main menu
        if (backButtonToMainMenu2 != null)
        {
            backButtonToMainMenu2.SetActive(true);
        }
    }

    public void ClearDrawing()
    {
        // Call the ClearDrawing method from the ARDrawOnPlane script
        if (arDrawOnPlane != null)
        {
            arDrawOnPlane.ClearDrawing();
        }
    }

    public void back()
    {
        SceneManager.LoadScene("Belajar");
    }

    public void SetImage(Sprite newSprite)
    {
        if (image != null)
        {
            Debug.Log("Setting new image: " + newSprite.name);

            // Ensure the image GameObject is active
            // image.SetActive(true);

            // Destroy the existing Image component
            Image existingImage = image.GetComponent<Image>();
            if (existingImage != null)
            {
                Debug.Log("Destroying existing Image component");
                Destroy(existingImage);
            }

            // Add a new Image component with the new sprite
            Image newImage = image.AddComponent<Image>();
            if (newImage != null)
            {
                Debug.Log("Adding new Image component with sprite: " + newSprite.name);
                newImage.sprite = newSprite;
                newImage.preserveAspect = true; // Optional: Preserve aspect ratio
            }
            else
            {
                Debug.LogError("Failed to add new Image component");
            }
        }
        else
        {
            Debug.LogError("Image GameObject is null");
        }
    }

    public void TraceButton()
    {
        SceneManager.LoadScene("TestDraw");
    }
}