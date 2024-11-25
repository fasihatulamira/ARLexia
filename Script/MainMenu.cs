using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ImagePopUp; // Reference to the ImagePopUp GameObject

    void Start()
    {
        // Show the ImagePopUp when the scene starts
        ImagePopUp.SetActive(true);
    }

    public void ExitPopUp()
    {
        // Hide the ImagePopUp when the ButtonExit is clicked
        ImagePopUp.SetActive(false);
    }

    public void Belajar()
    {
        // Load the "Belajar" scene when the BelajarButton is clicked
        SceneManager.LoadScene("Belajar");
    }

    public void back()
    {
        // Load the "HomePage" scene when the back button is clicked
        SceneManager.LoadScene("HomePage");
    }
}