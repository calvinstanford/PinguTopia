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

    public List<Nurturer> nur;
    public int pinguBabyCount = 0;
    public int pingusCount = 0;
    public int huntersCount = 0;
    public int nurturersCount = 0;

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
