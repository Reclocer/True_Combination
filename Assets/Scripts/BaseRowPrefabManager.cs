using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Main))]
public class BaseRowPrefabManager : MonoBehaviour
{    
    protected GameObject _prefabCell;
    protected Main _main; 

    protected int _cellAmount = 3;
    protected int _maxValueInCell = 5;    
    protected GameObject _cell;   

    private void Awake()
    {
        
    }

    private void Start()
    {
        _main = GetComponent<Main>();
        _prefabCell = _main.PrefabCell;
        _cellAmount = _main.CellAmount;
        _maxValueInCell = _main.MaxValueInCell;
    }
}
