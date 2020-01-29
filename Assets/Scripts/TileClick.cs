using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TileClick : MonoBehaviour
{
    private GameObject _main;
    private int _maxValue = 0;
    private string _sValue;

    public void ClickTile()
    {
        _sValue = GetComponentInChildren<Text>().text;
        GetComponentInChildren<Text>().text = IncrementValue(_sValue);
    }
    
    /// <summary>
    /// Прибавление значения в ячейке
    /// </summary>
    /// <param name="SMy">Текст в ячейке</param>
    /// <returns></returns>
    private string IncrementValue(string sMy)
    {
        int value = Convert.ToInt32(sMy);
        int maxValue = _maxValue -1;

        if (value <= maxValue )
        {
            return sMy = Convert.ToString(value + 1);
        }
        else
        {
            return sMy = Convert.ToString(1);
        }
    }

    private void Awake()
    {
        _main = GameObject.FindGameObjectWithTag("main");
    }

    void Start()
    {        
        _maxValue = _main.GetComponent<Main>().MaxValueInTail;

        GetComponent<Button>().onClick.AddListener(ClickTile);
    }
}

    
