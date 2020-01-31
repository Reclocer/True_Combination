using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RowSpawner : MonoBehaviour
{
    //[Header("Prefabs")]
    public GameObject EmptyRow;
    public GameObject EarlyRow;
    public GameObject WinIcon;
    public GameObject LoseIcon;

    private GameObject _prefabRow;
    [SerializeField] private Main _main;   
    private List<GameObject> _listCells;
    private List<int> _earlyListValuesInCells;      
    private GameObject _cellFirstValue;    
    private GameObject _cellGeneralValue;
    private string _stringGeneralValue;
    private GameObject _cell;

    private GameObject _row;    
    private int _rowAmountNow = 0;
    [SerializeField]private int _rowMaxAmount = 7;

    private int _cellAmount = 0;
    private int _maxValueInCell = 0;      
    
    void Start()
    {        
        _prefabRow = _main.PrefabRow;
        _cellAmount = _main.CellAmount;
        _maxValueInCell = _main.MaxValueInCell;        

        _row = Main.InstantiateUIPrefab(_prefabRow, gameObject);// Create first row        
        _rowAmountNow++;
    }

    public void ClickOnDone()//оптимизировать?
    {        
        _earlyListValuesInCells = _main.EarlyRowPrefab.GetComponent<EarlyRowPrefabManager>().ListValuesInCells;        
        _listCells = _row.GetComponentInChildren<RowPrefabManager>()._listCells;

        _cellFirstValue = GameObject.FindGameObjectWithTag("firstValue");         
        _cellFirstValue.GetComponentInChildren<Text>().text = OutputFirstValue();
        _cellFirstValue.tag = "Untagged";

        _cellGeneralValue = GameObject.FindGameObjectWithTag("generalValue");
        _stringGeneralValue = OutputGeneralValue();
        _cellGeneralValue.GetComponentInChildren<Text>().text = _stringGeneralValue;        
        _cellGeneralValue.tag = "Untagged";

        if (_rowAmountNow <= _rowMaxAmount) // check amount rows, if < _rowMaxAmount
        {
            if (_rowAmountNow != _rowMaxAmount)
            {
                if (_stringGeneralValue == Convert.ToString(_cellAmount))
                {
                    UnInteractableCells();
                    EmptyRow.SetActive(false);                    
                    WinIcon.SetActive(true);
                }
                else
                {
                    UnInteractableCells();
                    _row = Main.InstantiateUIPrefab(_prefabRow, gameObject); // create new row, if not win 
                    _rowAmountNow++;
                }
            }
            else if (_stringGeneralValue == Convert.ToString(_cellAmount))
            {
                UnInteractableCells();
                EmptyRow.SetActive(false);                
                WinIcon.SetActive(true);
            }
            else
            {
                UnInteractableCells();
                EmptyRow.SetActive(false);
                LoseIcon.SetActive(true);
            }
            
        }
        else // if amount rows >= _rowMaxAmount
        {
            UnInteractableCells();
            EmptyRow.SetActive(false);
            LoseIcon.SetActive(true);
        }
    }   

    /// <summary>
    /// Output row's first value
    /// </summary>
    /// <returns></returns>
    private string OutputFirstValue()
    {
        int firstValue = 0;
        int digit = 1;

        while (digit <= _maxValueInCell)
        {
            if (_earlyListValuesInCells[0] == digit)
            {
                if (Convert.ToInt32(_listCells[0].GetComponentInChildren<Text>().text) == digit)
                {
                    firstValue++;
                }
                else
                {
                    if (Convert.ToInt32(_listCells[1].GetComponentInChildren<Text>().text) == digit)
                    {
                        firstValue++;
                    }
                    else
                    {
                        if (Convert.ToInt32(_listCells[2].GetComponentInChildren<Text>().text) == digit)
                        {
                            firstValue++;
                        }
                        else if(_cellAmount > 3)
                        {

                            if (Convert.ToInt32(_listCells[3].GetComponentInChildren<Text>().text) == digit)
                            {
                                firstValue++;
                            }
                            else if (_cellAmount > 4)
                            {
                                if (Convert.ToInt32(_listCells[4].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                if (_earlyListValuesInCells[1] == digit)
                {
                    if (Convert.ToInt32(_listCells[0].GetComponentInChildren<Text>().text) == digit)
                    {
                        firstValue++;
                    }
                    else
                    {
                        if (Convert.ToInt32(_listCells[1].GetComponentInChildren<Text>().text) == digit)
                        {
                            firstValue++;
                        }
                        else
                        {
                            if (Convert.ToInt32(_listCells[2].GetComponentInChildren<Text>().text) == digit)
                            {
                                firstValue++;
                            }

                            else if (_cellAmount > 3)
                            {
                                if (Convert.ToInt32(_listCells[3].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                                else if (_cellAmount > 4)
                                {
                                    if (Convert.ToInt32(_listCells[4].GetComponentInChildren<Text>().text) == digit)
                                    {
                                        firstValue++;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (_earlyListValuesInCells[2] == digit)
                    {
                        if (Convert.ToInt32(_listCells[0].GetComponentInChildren<Text>().text) == digit)
                        {
                            firstValue++;
                        }
                        else
                        {
                            if (Convert.ToInt32(_listCells[1].GetComponentInChildren<Text>().text) == digit)
                            {
                                firstValue++;
                            }
                            else
                            {
                                if (Convert.ToInt32(_listCells[2].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                                else if (_cellAmount > 3)
                                {
                                    if (Convert.ToInt32(_listCells[3].GetComponentInChildren<Text>().text) == digit)
                                    {
                                        firstValue++;
                                    }
                                    else if (_cellAmount > 4)
                                    {
                                        if (Convert.ToInt32(_listCells[4].GetComponentInChildren<Text>().text) == digit)
                                        {
                                            firstValue++;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else if (_cellAmount > 3)
                    {

                        if (_earlyListValuesInCells[3] == digit)
                        {

                            if (Convert.ToInt32(_listCells[0].GetComponentInChildren<Text>().text) == digit)
                            {
                                firstValue++;
                            }
                            else
                            {
                                if (Convert.ToInt32(_listCells[1].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                                else
                                {
                                    if (Convert.ToInt32(_listCells[2].GetComponentInChildren<Text>().text) == digit)
                                    {
                                        firstValue++;
                                    }
                                    else if (_cellAmount > 3)
                                    {
                                        if (Convert.ToInt32(_listCells[3].GetComponentInChildren<Text>().text) == digit)
                                        {

                                            firstValue++;
                                        }
                                        else if (_cellAmount > 4)
                                        {
                                            if (Convert.ToInt32(_listCells[4].GetComponentInChildren<Text>().text) == digit)
                                            {
                                                firstValue++;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        else if(_cellAmount > 4)
                        {
                            if (_earlyListValuesInCells[4] == digit)
                            {

                                if (Convert.ToInt32(_listCells[0].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                                else
                                {
                                    if (Convert.ToInt32(_listCells[1].GetComponentInChildren<Text>().text) == digit)
                                    {
                                        firstValue++;
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(_listCells[2].GetComponentInChildren<Text>().text) == digit)
                                        {
                                            firstValue++;
                                        }
                                        else if (_cellAmount > 3)
                                        {
                                            if (Convert.ToInt32(_listCells[3].GetComponentInChildren<Text>().text) == digit)
                                            {

                                                firstValue++;
                                            }
                                            else if (_cellAmount > 4)
                                            {
                                                if (Convert.ToInt32(_listCells[4].GetComponentInChildren<Text>().text) == digit)
                                                {
                                                    firstValue++;
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
            digit++;
        }       
        
        return Convert.ToString(firstValue);
    }

    /// <summary>
    /// Output row's general value
    /// </summary>
    /// <param name="s"></param>
    /// <param name="es"></param>
    /// <returns></returns>
    private string OutputGeneralValue()
    {
        int generalValueI = 0;
        int i = 0;

        while (i < _cellAmount)
        {
            string stringEarlyValue = Convert.ToString(_earlyListValuesInCells[i]);
            _cell = _listCells[i];
            string stringValue = _cell.GetComponentInChildren<Text>().text;

            if (stringEarlyValue == stringValue)
            {
                generalValueI++;
            }

            i++;
        }

        return Convert.ToString(generalValueI);
    }

    /// <summary>
    /// Tiles interectable disabled
    /// </summary>
    private void UnInteractableCells()
    {        
        foreach (GameObject cell in _listCells)
        {
            cell.GetComponent<Button>().interactable = false;
        }
    }
}
