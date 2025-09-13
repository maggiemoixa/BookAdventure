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






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int characterLevel = 32;
        int NextSkillLevel = GenerateCharacter("Jill", characterLevel);
        Debug.Log(NextSkillLevel);
        Debug.Log(GenerateCharacter("Faye", characterLevel));
        ComputeAge();


        // The dollar sign $ lets you embed variables into a string!!!
        Debug.Log($"{FirstName} wrote this code!");
        Debug.Log($"{CharacterName} is the protagonist!");
    }

    public int GenerateCharacter(string name, int level)
    {
        // Debug.LogFormat("Character: {0} - Level: {1}", name, level);
        
        return level += 5;
    }

    void ComputeAge()
    {         
        Debug.Log(CurrentAge + AddedAge);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
