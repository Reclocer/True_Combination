using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//====================

using System.IO;
using System.Xml;

public class Main : MonoBehaviour
{
    public GameObject PrefabRow;    
    public GameObject PrefabCell;    
    public GameObject TextValueTextAmountCells;
    public GameObject TextValueTextMaxValueInCell;
    public GameObject EarlyRowPrefab;
    
    public GameObject LanguageChangeButton;            
    public GameObject AmountCellsSlider;            
    public GameObject MaxValueInCellSlider;            
    [HideInInspector] public int CellAmount = 3;             
    [HideInInspector] public int MaxValueInCell = 5;             
    
    //localization
    [HideInInspector]public List<string> Names;
    [HideInInspector]public GameObject[] Words;

     void Awake()
    {        
        //PrefabRow = Resources.Load("Assets/Resources/Prefab_Row(attempt)") as GameObject;
        //PrefabTail = Resources.Load("Assets/Resources/Prefab_Cell") as GameObject;
    }

    void Start()
    {        
        Names = new List<string>();
        //LocalizationManager();                
    }

    /// <summary>
    /// Create UI instance and add this object in child 
    /// </summary>
    /// <param name="prefab">Prefab UI object to be created</param>
    /// <param name="prefabParentOject">Parent UI object in which you need to add the child object</param>
    /// <returns></returns>
    public static GameObject InstantiateUIPrefab(GameObject prefab, GameObject prefabParentOject)
    {
        GameObject objectUI = Instantiate(prefab, prefabParentOject.transform, false);        
        return objectUI;
    }

    public void LocalizationManager ()
    {
        Words = GameObject.FindGameObjectsWithTag("changeLanguage");
        string language = PlayerPrefs.GetString("Language");
        XmlDocument xmlDock = new XmlDocument();
        xmlDock.Load("Assets/Resourсes/" + language + ".xml"); 
        XmlNodeList list = xmlDock.GetElementsByTagName("word");           

        foreach (XmlNode tag in list)
        {
            Names.Add(tag.InnerText);            
        }        
        int length = Words.Length;
        for(int i = 0; i < length; i++)
        {
            Words[i].GetComponent<Text>().text = Names[i];
        }
    }
    
}
