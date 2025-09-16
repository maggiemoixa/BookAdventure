using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //public means other scripts can see this variable
    //private means only this script can see this variable
    public int CurrentAge = 30;
    public int AddedAge = 1;

    //int is simple integers, no decimals
    //floats are for decimals
    //strings are text
    //bools are true/false
    public int CharacterHealth = 100;
    public float Pi = 3.14f;
    public string FirstName = "Maggie";
    public string CharacterName = "Doodoo";
    public bool IsAuthor = true;
    public bool PureOfHeart = true;
    public bool HasSecretIncantation = false;
    public string RareItem = "Relic Stone";
    public string CharacterAction = "Attack";

    List<string> QuestPartyMembers = new List<string>()
    {
    "Grim the Barbarian",
    "Merlin the Wise",
    "Sterling the Knight"
    };

    Dictionary<string, int> ItemInventory = new Dictionary<string, int>()
    {
        { "Potion", 5 },
        { "Antidote", 7 },
        { "Aspirin", 1 }
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int characterLevel = 32;
        int NextSkillLevel = GenerateCharacter("Jill", characterLevel);
        Debug.Log(NextSkillLevel);
        Debug.Log(GenerateCharacter("Faye", characterLevel));
        ComputeAge();
        OpenTreasureChamber();

        PrintCharacterAction();
        QuestPartyMembers.Add("Craven the Necromancer");
       
        Debug.LogFormat("Party Members: {0}", QuestPartyMembers.Count);

        Debug.LogFormat("Items: {0}", ItemInventory.Count);

        // The dollar sign $ lets you embed variables into a string!!!
        Debug.Log($"{FirstName} wrote this code!");
        Debug.Log($"{CharacterName} is the protagonist!");
    }

    public int GenerateCharacter(string name, int level)
    {
        // Debug.LogFormat("Character: {0} - Level: {1}", name, level);
        
        return level += 5;
    }

    public void PrintCharacterAction()
    {
        switch (CharacterAction)
        {
            case "Potion":
            case "Heal":
            Debug.Log("Potion sent.");
            break;

            case "Attack":
                Debug.Log("To arms!");
            break;

        default:
                Debug.Log("Shields up.");
            break;
    }
    }

    void ComputeAge()
    {         
        Debug.Log(CurrentAge + AddedAge);
    }

    public void OpenTreasureChamber()
    {
        if (PureOfHeart && RareItem == "Relic Stone")
        {
            if (!HasSecretIncantation)
            {
                Debug.Log("You have the spirit, but not the knowledge.");
            }
            else
            {
                Debug.Log("The treasure is yours, worthy hero!");
            }
        }
        else
        {
            Debug.Log("Come back when you have what it takes.");
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
