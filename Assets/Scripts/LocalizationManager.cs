using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalizationManager : MonoBehaviour
{
    public void SetLanguageRu()
    {
        PlayerPrefs.SetString("Language", "Ru");
        SceneManager.LoadScene("startMenu");
    }

    public void SetLanguageEn()
    {
        PlayerPrefs.SetString("Language", "En");
        SceneManager.LoadScene("startMenu");
    }
}
