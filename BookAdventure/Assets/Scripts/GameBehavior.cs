using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class GameBehavior : MonoBehaviour
{

    public int MaxItems = 4;
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;
    public Button WinButton;
    public Button LossButton;

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }
    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;

            ItemText.text = "Items Collected: " + Items;
            
        

            if(_itemsCollected >= MaxItems)
            {
            WinButton.gameObject.SetActive(true);

            UpdateScene("You've found all the items!");


            Time.timeScale = 0f;
            }

            else
            {
            ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more!";
            }
        }

    }




    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Player Health: " + HP;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if (_playerHP <= 0)
            {
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
            }
            else
            {
                ProgressText.text = "Ouch... That's gotta hurt.";
            }


        }
    }

   void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }
 
    void Update()
    {
        
    }
}
