using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.Xml;
using System.Xml.Serialization;

[RequireComponent(typeof(Main))]
public class UIBehaviour : MonoBehaviour
{
    private Main _main;
    private GameObject _languageChangeButton;
    private string _language;
    private GameObject _amountCellsSlider;            
    private GameObject _maxValueInCellSlider;

    private void Awake()
    {
        _main = GetComponent<Main>();

        PlayerPrefsLoad();        
    }

    private void PlayerPrefsLoad()
    {
        // load last used language
        //_languageChangeButton = _main.GetComponent<Main>().LanguageChangeButton;
        //if (PlayerPrefs.HasKey("Language"))
        //{
        //    _languageChangeButton.GetComponentInChildren<Text>().text = _language = PlayerPrefs.GetString("Language");
        //    _main.LocalizationManager();
        //}

        // Load last amountTiles in slider
        _amountCellsSlider = _main.AmountCellsSlider;
        if (PlayerPrefs.HasKey("CellAmount"))
        {
            _amountCellsSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("CellAmount");
        }

        // Load last maxValueInTail in slider
        _maxValueInCellSlider = _main.MaxValueInCellSlider;
        if (PlayerPrefs.HasKey("MaxValueInCell"))
        {
            _maxValueInCellSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MaxValueInCell");
        }
    }

    /// <summary>
    /// AmountTiles slider function
    /// </summary>
    /// <param name="amount"></param>
    public void SetCellAmount(float amount)            
    {
        _main.CellAmount = Convert.ToInt32(amount);        
        _main.TextValueTextAmountCells.GetComponent<Text>().text = Convert.ToString(amount);        
        PlayerPrefs.SetFloat("CellAmount", amount);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// MaxValueInTails slider function
    /// </summary>
    /// <param name="value"></param>
    public void SetMaxValueInCell(float value)             
    {
        _main.MaxValueInCell = Convert.ToInt32(value);        
        _main.TextValueTextMaxValueInCell.GetComponent<Text>().text = Convert.ToString(value);
        PlayerPrefs.SetFloat("MaxValueInCell", value);
        PlayerPrefs.Save();
    }

    public void ConstantMinValueInCell(Slider slider)
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
            _main.LocalizationManager();

            SceneManager.LoadScene("Main");
        }
        else
        {
            _language = "Eng";
            _languageChangeButton.GetComponentInChildren<Text>().text = _language;
            PlayerPrefs.SetString("Language", _language);
            PlayerPrefs.Save();
            _main.LocalizationManager();

            SceneManager.LoadScene("Main");
        }
        
    }

    
}
