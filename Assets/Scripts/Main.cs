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
    public GameObject PrefabTail;    
    public GameObject PrefabValueTextAmountTiles;
    public GameObject PrefabValueTextMaxValueInTail;
    public GameObject EarlyRowPrefab;
    
    public GameObject LanguageChangeButton;            //@@@@
    public GameObject AmountTilesSlider;            //@@@@
    public GameObject MaxValueInTailSlider;            //@@@@
    [HideInInspector] public int TileAmount = 0;             //@@@@
    [HideInInspector] public int MaxValueInTail = 0;             //@@@@
    
    public List<string> names;
    public GameObject[] words;

     void Awake()
    {        
        //PrefabRow = Resources.Load("Assets/Resources/Prefab_Row(attempt)") as GameObject;
        //PrefabTail = Resources.Load("Assets/Resources/Prefab_Tail") as GameObject;
    }

    void Start()
    {        
        names = new List<string>();
        //LocalizationManager();
        //string str = Convert.ToString(TileAmount);
        //PrefabValueTextAmountTiles.GetComponent<TextMeshProUGUI>().text = str;        
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
        words = GameObject.FindGameObjectsWithTag("changeLanguage");
        string language = PlayerPrefs.GetString("Language");
        XmlDocument xmlDock = new XmlDocument();
        xmlDock.Load("Assets/Resourсes/" + language + ".xml"); 
        XmlNodeList list = xmlDock.GetElementsByTagName("word");           

        foreach (XmlNode tag in list)
        {
            names.Add(tag.InnerText);            
        }        
        int length = words.Length;
        for(int i = 0; i < length; i++)
        {
            words[i].GetComponent<Text>().text = names[i];
        }
    }
    
}
