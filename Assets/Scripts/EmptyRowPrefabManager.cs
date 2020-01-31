using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyRowPrefabManager : BaseRowPrefabManager, IHaveSpawnCells
{
    private GameObject PrefabParentUIObject;
    private string _sValueInCell = "X";
    private List<GameObject> _listTiles;

    void Start()
    {
        PrefabParentUIObject = gameObject;
        _listTiles = new List<GameObject>();
        SpawnCells();
    }

    /// <summary>
    /// Create tiles with string argument
    /// </summary>
    /// <param name="_sValueInTail"></param>
    public void SpawnCells()
    {
        int i = 0;

        do
        {
            _cell = Main.InstantiateUIPrefab(_prefabCell, PrefabParentUIObject);
            _cell.GetComponentInChildren<Text>().text = _sValueInCell;
            _cell.GetComponent<Button>().interactable = false;
            i++;
        }
        while (i < _cellAmount);
    }
}
