using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseRowPrefabManager : MonoBehaviour
{    
    protected GameObject PrefabTile;
    protected GameObject _main;
    

    protected int _tileAmount = 0;
    protected int _maxValueInTail = 0;    
    protected GameObject _tile;   

    private void Awake()
    {        
        _main = GameObject.FindGameObjectWithTag("main");
        PrefabTile = _main.GetComponent<Main>().PrefabTail;
        _tileAmount = _main.GetComponent<Main>().TileAmount;
        _maxValueInTail = _main.GetComponent<Main>().MaxValueInTail;        
    }

    void Start()
    {    


    }

}
