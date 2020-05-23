using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour
{
    public void exit()
    {
        Application.Quit();
    }

    public void openTestGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void openMainMenu()
    {
        SceneManager.LoadScene("startMenu");
    }
}
