using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
using CustomExtensions;
using System.Linq;

public class GameBehavior : MonoBehaviour, IManager
{
    public PlayerBehavior playerBehavior;

    void OnEnable()
    {
        GameObject player = GameObject.Find("Player");
        playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;
        debug("Jump event subscribed...");
    }

    private void OnDisable()
    {
        playerBehavior.playerJump -= HandlePlayerJump;
        debug("Jump event unsubscribed...");
    }

    public void HandlePlayerJump()
    {
        debug("Player has jumped...");
    }


    public Stack<Loot> LootStack = new Stack<Loot>();
    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public int MaxItems = 4;
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;
    public Button WinButton;
    public Button LossButton;

    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;


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
        Utilities.RestartLevel(-1);
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
        Initialize();
    }
 
    public void Initialize()
    {
        _state = "Game Manager initialized..";
        _state.FancyDebug();
        Debug.Log(_state);

        debug(_state);
        LogWithDelegate(debug);

        LootStack.Push(new Loot("Sword of Doom", 5));
        LootStack.Push(new Loot("HP Boost", 1));
        LootStack.Push(new Loot("Golden Key", 3));
        LootStack.Push(new Loot("Pair of Winged Boots", 2));
        LootStack.Push(new Loot("Mythril Bracer", 4));
        FilterLoot();

        var itemShop = new Shop<Collectable>();
        itemShop.AddItem(new Potion());
        itemShop.AddItem(new Antidote());
        Debug.Log("Items for sale: " + itemShop.GetStockCount<Potion>());

    }

    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task...");
    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void PrintLootReport()
    {
        var currentItem = LootStack.Pop();
        var nextItem = LootStack.Peek();


        Debug.LogFormat("You got a {0}! You've got a good chance of finding a{1} next!", currentItem.name, nextItem.name);
        Debug.LogFormat("There are {0} random loot items waiting for you!", LootStack.Count);
    }

    public void FilterLoot()
    {
        var rareLoot = from item in LootStack
            // 2
                        where item.rarity >= 3
                        // 3
                        orderby item.rarity
                        // 4
                        select item;
        
        foreach (var item in rareLoot)
        {
        Debug.LogFormat("Rare item: {0}!", item.name);
        }
    }

    public bool LootPredicate(Loot loot)
    {
    return loot.rarity >= 3;
    }

}
