using UnityEngine;
using UnityEngine.UI;
using System;

public class CellClick : MonoBehaviour
{
    [SerializeField] private Main _main;
    private int _maxValue = 0;
    private string _sValue;
    
    void Start()
    {
        GameObject main = GameObject.FindGameObjectWithTag("main");
        _main = main.GetComponent<Main>();
        _maxValue = _main.MaxValueInCell;

        GetComponent<Button>().onClick.AddListener(ClickTile);
    }

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
        int maxValue = _maxValue - 1;

        if (value <= maxValue)
        {
            return sMy = Convert.ToString(value + 1);
        }
        else
        {
            return sMy = Convert.ToString(1);
        }
    }
}



