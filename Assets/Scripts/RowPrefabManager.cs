using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RowPrefabManager : BaseRowPrefabManager, IHaveSpawnCells
{    
    private GameObject PrefabParentUIObject;    
    public List<GameObject> _listCells;   

    void Start()
    {        
        PrefabParentUIObject = gameObject;
        _listCells = new List<GameObject>();        

        SpawnCells();
    }

    /// <summary>
    /// Create tiles without arguments
    /// </summary>
    public void SpawnCells()
    {
        int i = 0;
        do
        {
            _cell = Main.InstantiateUIPrefab(_prefabCell, PrefabParentUIObject);
            _listCells.Add(_cell);
            i++;
        }
        while (i < _cellAmount);
    }
}
