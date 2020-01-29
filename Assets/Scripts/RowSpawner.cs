using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RowSpawner : MonoBehaviour
{
    //[Header("Prefabs")]
    public GameObject PrefabEmptyRow;
    public GameObject PrefabEarlyRow;
    public GameObject PrefabWinIcon;
    public GameObject PrefabLoseIcon;

    private GameObject _prefabRow;
    private GameObject _main;   
    private List<GameObject> _listTiles;
    private List<int> _earlyListValuesInTails;      
    private GameObject _tileFirstValue;    
    private GameObject _tileGeneralValue;
    private string _stringGeneralValue;
    private GameObject _tile;

    private GameObject _row;    
    private int _rowAmountNow = 0;
    private int _rowMaxAmount = 7;

    private int _tileAmount = 0;
    private int _maxValueInTail = 0;
    

       
    
    void Start()
    {
        _main = GameObject.FindGameObjectWithTag("main");
        _prefabRow = _main.GetComponent<Main>().PrefabRow;
        _tileAmount = _main.GetComponent<Main>().TileAmount;
        _maxValueInTail = _main.GetComponent<Main>().MaxValueInTail;        

        _row = Main.InstantiateUIPrefab(_prefabRow, gameObject);// Create first row        
        _rowAmountNow++;
    }

    public void ClickOnDone()
    {        
        _earlyListValuesInTails = _main.GetComponent<Main>().EarlyRowPrefab.GetComponent<EarlyRowPrefabManager>().ListValuesInTails;        
        _listTiles = _row.GetComponentInChildren<RowPrefabManager>()._listTiles;

        _tileFirstValue = GameObject.FindGameObjectWithTag("firstValue");         
        _tileFirstValue.GetComponentInChildren<Text>().text = OutputFirstValue();
        _tileFirstValue.tag = "Untagged";

        _tileGeneralValue = GameObject.FindGameObjectWithTag("generalValue");
        _stringGeneralValue = OutputGeneralValue();
        _tileGeneralValue.GetComponentInChildren<Text>().text = _stringGeneralValue;        
        _tileGeneralValue.tag = "Untagged";

        if (_rowAmountNow <= _rowMaxAmount) // check amount rows, if < _rowMaxAmount
        {
            if (_rowAmountNow != _rowMaxAmount)
            {
                if (_stringGeneralValue == Convert.ToString(_tileAmount))
                {
                    UnInteractableTiles();
                    PrefabEmptyRow.SetActive(false);                    
                    PrefabWinIcon.SetActive(true);
                }
                else
                {
                    UnInteractableTiles();
                    _row = Main.InstantiateUIPrefab(_prefabRow, gameObject); // create new row, if not win 
                    _rowAmountNow++;
                }
            }
            else if (_stringGeneralValue == Convert.ToString(_tileAmount))
            {
                UnInteractableTiles();
                PrefabEmptyRow.SetActive(false);                
                PrefabWinIcon.SetActive(true);
            }
            else
            {
                UnInteractableTiles();
                PrefabEmptyRow.SetActive(false);
                PrefabLoseIcon.SetActive(true);
            }
            
        }
        else // if amount rows >= _rowMaxAmount
        {
            UnInteractableTiles();
            PrefabEmptyRow.SetActive(false);
            PrefabLoseIcon.SetActive(true);
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

        while (digit <= _maxValueInTail)
        {
            if (_earlyListValuesInTails[0] == digit)
            {
                if (Convert.ToInt32(_listTiles[0].GetComponentInChildren<Text>().text) == digit)
                {
                    firstValue++;
                }
                else
                {
                    if (Convert.ToInt32(_listTiles[1].GetComponentInChildren<Text>().text) == digit)
                    {
                        firstValue++;
                    }
                    else
                    {
                        if (Convert.ToInt32(_listTiles[2].GetComponentInChildren<Text>().text) == digit)
                        {
                            firstValue++;
                        }
                        else if(_tileAmount > 3)
                        {

                            if (Convert.ToInt32(_listTiles[3].GetComponentInChildren<Text>().text) == digit)
                            {
                                firstValue++;
                            }
                            else if (_tileAmount > 4)
                            {
                                if (Convert.ToInt32(_listTiles[4].GetComponentInChildren<Text>().text) == digit)
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
                if (_earlyListValuesInTails[1] == digit)
                {
                    if (Convert.ToInt32(_listTiles[0].GetComponentInChildren<Text>().text) == digit)
                    {
                        firstValue++;
                    }
                    else
                    {
                        if (Convert.ToInt32(_listTiles[1].GetComponentInChildren<Text>().text) == digit)
                        {
                            firstValue++;
                        }
                        else
                        {
                            if (Convert.ToInt32(_listTiles[2].GetComponentInChildren<Text>().text) == digit)
                            {
                                firstValue++;
                            }

                            else if (_tileAmount > 3)
                            {
                                if (Convert.ToInt32(_listTiles[3].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                                else if (_tileAmount > 4)
                                {
                                    if (Convert.ToInt32(_listTiles[4].GetComponentInChildren<Text>().text) == digit)
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
                    if (_earlyListValuesInTails[2] == digit)
                    {
                        if (Convert.ToInt32(_listTiles[0].GetComponentInChildren<Text>().text) == digit)
                        {
                            firstValue++;
                        }
                        else
                        {
                            if (Convert.ToInt32(_listTiles[1].GetComponentInChildren<Text>().text) == digit)
                            {
                                firstValue++;
                            }
                            else
                            {
                                if (Convert.ToInt32(_listTiles[2].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                                else if (_tileAmount > 3)
                                {
                                    if (Convert.ToInt32(_listTiles[3].GetComponentInChildren<Text>().text) == digit)
                                    {
                                        firstValue++;
                                    }
                                    else if (_tileAmount > 4)
                                    {
                                        if (Convert.ToInt32(_listTiles[4].GetComponentInChildren<Text>().text) == digit)
                                        {
                                            firstValue++;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else if (_tileAmount > 3)
                    {

                        if (_earlyListValuesInTails[3] == digit)
                        {

                            if (Convert.ToInt32(_listTiles[0].GetComponentInChildren<Text>().text) == digit)
                            {
                                firstValue++;
                            }
                            else
                            {
                                if (Convert.ToInt32(_listTiles[1].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                                else
                                {
                                    if (Convert.ToInt32(_listTiles[2].GetComponentInChildren<Text>().text) == digit)
                                    {
                                        firstValue++;
                                    }
                                    else if (_tileAmount > 3)
                                    {
                                        if (Convert.ToInt32(_listTiles[3].GetComponentInChildren<Text>().text) == digit)
                                        {

                                            firstValue++;
                                        }
                                        else if (_tileAmount > 4)
                                        {
                                            if (Convert.ToInt32(_listTiles[4].GetComponentInChildren<Text>().text) == digit)
                                            {
                                                firstValue++;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        else if(_tileAmount > 4)
                        {
                            if (_earlyListValuesInTails[4] == digit)
                            {

                                if (Convert.ToInt32(_listTiles[0].GetComponentInChildren<Text>().text) == digit)
                                {
                                    firstValue++;
                                }
                                else
                                {
                                    if (Convert.ToInt32(_listTiles[1].GetComponentInChildren<Text>().text) == digit)
                                    {
                                        firstValue++;
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(_listTiles[2].GetComponentInChildren<Text>().text) == digit)
                                        {
                                            firstValue++;
                                        }
                                        else if (_tileAmount > 3)
                                        {
                                            if (Convert.ToInt32(_listTiles[3].GetComponentInChildren<Text>().text) == digit)
                                            {

                                                firstValue++;
                                            }
                                            else if (_tileAmount > 4)
                                            {
                                                if (Convert.ToInt32(_listTiles[4].GetComponentInChildren<Text>().text) == digit)
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

        while (i < _tileAmount)
        {
            string stringEarlyValue = Convert.ToString(_earlyListValuesInTails[i]);
            _tile = _listTiles[i];
            string stringValue = _tile.GetComponentInChildren<Text>().text;

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
    private void UnInteractableTiles()
    {        
        foreach (GameObject tile in _listTiles)
        {
            tile.GetComponent<Button>().interactable = false;
        }
    }
}
