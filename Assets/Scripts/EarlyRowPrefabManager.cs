using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EarlyRowPrefabManager : BaseRowPrefabManager
{    
    private GameObject PrefabParentUIObject;    
    private int _valueInTail = 0;    

    public List<int> ListValuesInTails
    {
        get;
        private set;
    }

    void Start()
    {
        PrefabParentUIObject = gameObject;       
        ListValuesInTails = new List<int>();
        
        int i = 0;
        _maxValueInTail++;//@@@@@@@@@@@@22

        do
        {            
            int a = 0;

            while (a == 0)
            {                
                _valueInTail = UnityEngine.Random.Range(1, _maxValueInTail);
                a++;                

                if (i != 0)
                {                                       
                    foreach (int value in ListValuesInTails)
                    {
                        if (value == _valueInTail)
                        {
                            a = 0;                            
                        }                        
                    }
                }                 
            }

            ListValuesInTails.Add(_valueInTail);

            _tile = Main.InstantiateUIPrefab(PrefabTile, gameObject);
            _tile.GetComponentInChildren<Text>().text = Convert.ToString(_valueInTail);
            _tile.GetComponent<Button>().interactable = false;
            
            i++;
        }
        while (i < _tileAmount);        
    }

    
    void Update()
    {
        
    }
}
