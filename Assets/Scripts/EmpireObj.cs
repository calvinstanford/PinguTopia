using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireObj : MonoBehaviour
{
   /*
   Class functioning as our main Empire object.
   Will store many variables related to the 
   empire.  
   
   */
   public Penguin[] pingus;
   public Penguin[] hunters;
   public Penguin[] nurturers;
   public string pinguNum;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pinguNum = pingus.Length.ToString();
    }
}
