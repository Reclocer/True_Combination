using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EarlyRowPrefabManager : BaseRowPrefabManager, IHaveSpawnCells
{    
    private GameObject PrefabParentUIObject;    
    private int _valueInCell = 0;    

    public List<int> ListValuesInCells
    {
        get;
        private set;
    }

    void Start()
    {
        PrefabParentUIObject = gameObject;       
        ListValuesInCells = new List<int>();
        SpawnCells();                
    }

    public void SpawnCells()
    {
        int i = 0;
        _maxValueInCell++;//????????

        do
        {
            int a = 0;

            while (a == 0)
            {
                _valueInCell = UnityEngine.Random.Range(1, _maxValueInCell);
                a++;

                if (i != 0)
                {
                    foreach (int value in ListValuesInCells)
                    {
                        if (value == _valueInCell)
                        {
                            a = 0;
                        }
                    }
                }
            }

            ListValuesInCells.Add(_valueInCell);

            _cell = Main.InstantiateUIPrefab(_prefabCell, gameObject);
            _cell.GetComponentInChildren<Text>().text = Convert.ToString(_valueInCell);
            _cell.GetComponent<Button>().interactable = false;

            i++;
        }
        while (i < _cellAmount);
    }
}
