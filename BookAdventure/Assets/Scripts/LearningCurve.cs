using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int CurrentAge = 30;
    public int AddedAge = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ComputeAge();
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
