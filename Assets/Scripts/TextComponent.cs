using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextComponent : MonoBehaviour
{

    [SerializeField] private string textRu;
    [SerializeField] private string textEn;

    void Start()
    {
        var textObj = GetComponent<Text>();
        var lang = PlayerPrefs.GetString("Language");
        Debug.Log("lang " + lang);
        if(lang == "En")
        {
            textObj.text = textEn;
        }
        else
        {
            textObj.text = textRu;
        }
    }

}
