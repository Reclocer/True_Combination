using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RowPrefabManager : BaseRowPrefabManager
{    
    private GameObject PrefabParentUIObject;    
    public List<GameObject> _listTiles;   

    void Start()
    {        
        PrefabParentUIObject = gameObject;
        _listTiles = new List<GameObject>();        

        SpawnTiles();
    }

    /// <summary>
    /// Create tiles without arguments
    /// </summary>
    private void SpawnTiles()
    {
        int i = 0;
        do
        {
            _tile = Main.InstantiateUIPrefab(PrefabTile, PrefabParentUIObject);
            _listTiles.Add(_tile);
            i++;
        }
        while (i < _tileAmount);
    }
}
