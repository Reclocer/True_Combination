using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyRowPrefabManager : BaseRowPrefabManager
{
    private GameObject PrefabParentUIObject;
    private string _sValueInTail = "X";
    private List<GameObject> _listTiles;


    /// <summary>
    /// Create tiles with string argument
    /// </summary>
    /// <param name="valueInTail"></param>
    private void SpawnTiles(string valueInTail)
    {
        int i = 0;        

        do
        {
            _tile = Main.InstantiateUIPrefab(PrefabTile, PrefabParentUIObject);
            _tile.GetComponentInChildren<Text>().text = valueInTail;
            _tile.GetComponent<Button>().interactable = false;
            i++;
        }
        while (i < _tileAmount);
    }

    void Start()
    {
        PrefabParentUIObject = gameObject;
        _listTiles = new List<GameObject>();
        SpawnTiles(_sValueInTail);
    }

    
    void Update()
    {
        
    }
}
