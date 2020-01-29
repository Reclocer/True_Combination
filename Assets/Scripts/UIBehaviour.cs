using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.Xml;
using System.Xml.Serialization;

public class UIBehaviour : MonoBehaviour
{
    private GameObject _main;
    private GameObject _languageChangeButton;
    private string _language;
    private GameObject _amountTilesSlider;            
    private GameObject _maxValueInTailSlider;



    /// <summary>
    /// AmountTiles slider function
    /// </summary>
    /// <param name="amount"></param>
    public void SetTileAmount(float amount)            
    {
        _main.GetComponent<Main>().GetComponent<Main>().TileAmount = Convert.ToInt32(amount);        
        _main.GetComponent<Main>().PrefabValueTextAmountTiles.GetComponent<Text>().text = Convert.ToString(amount);        
        PlayerPrefs.SetFloat("TileAmount", amount);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// MaxValueInTails slider function
    /// </summary>
    /// <param name="value"></param>
    public void SetMaxValueInTail(float value)             
    {
        _main.GetComponent<Main>().MaxValueInTail = Convert.ToInt32(value);        
        _main.GetComponent<Main>().PrefabValueTextMaxValueInTail.GetComponent<Text>().text = Convert.ToString(value);
        PlayerPrefs.SetFloat("MaxValueInTail", value);
        PlayerPrefs.Save();
    }

    public void ConstantMinValueInTail(Slider slider)
    {        
        slider.minValue = 5;
    }

    public void ClickRestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ClickLanguageChangeButton()
    {
        if (_language == "Eng")
        {
            _language = "Rus";
            _languageChangeButton.GetComponentInChildren<Text>().text = _language;
            PlayerPrefs.SetString("Language", _language);
            PlayerPrefs.Save();
            _main.GetComponent<Main>().LocalizationManager();

            SceneManager.LoadScene("Main");
        }
        else
        {
            _language = "Eng";
            _languageChangeButton.GetComponentInChildren<Text>().text = _language;
            PlayerPrefs.SetString("Language", _language);
            PlayerPrefs.Save();
            _main.GetComponent<Main>().LocalizationManager();

            SceneManager.LoadScene("Main");
        }
        
    }

    private void Awake()
    {
        _main = GameObject.FindGameObjectWithTag("main");
        
        // load last used language
        _languageChangeButton = _main.GetComponent<Main>().LanguageChangeButton;
        if (PlayerPrefs.HasKey("Language"))
        {
            _languageChangeButton.GetComponentInChildren<Text>().text = _language = PlayerPrefs.GetString("Language");
            _main.GetComponent<Main>().LocalizationManager();
        }


        // Load last amountTiles in slider
        _amountTilesSlider = _main.GetComponent<Main>().AmountTilesSlider;
        if (PlayerPrefs.HasKey("TileAmount"))
        {
            _amountTilesSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("TileAmount");
        }

        // Load last maxValueInTail in slider
        _maxValueInTailSlider = _main.GetComponent<Main>().MaxValueInTailSlider;
        if (PlayerPrefs.HasKey("MaxValueInTail"))
        {
            _maxValueInTailSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MaxValueInTail");
        }
    }

}
