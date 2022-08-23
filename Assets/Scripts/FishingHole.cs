using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHole : MonoBehaviour
{
    private int fishPop;
    public GameObject[] funHunters;
    private List<GameObject> availHunters  = new List<GameObject>();
    private GameObject[] huntersFishing;
    private float closestHunterDistance = 10000000000000f;
    private Penguin closestHunter, penguinScanned;
    private GameObject closestHunterObj;
    private Rigidbody2D rb;
    private float distance;
    
    public void getFished(){
    
      Debug.Log("Water pressed");
      int fl = funHunters.Length;
      int a = Random.Range(0, fl);

      List<int> penguinnumbers = new List<int>();
      closestHunter = funHunters[a].GetComponent<Penguin>();
      //Debug.Log("CLOSEST HUNTER DISTANCE: "+closestHunterDistance);
        if(!closestHunter.imFishing){
        
            closestHunter.goFishing();
            print(closestHunter.name);
        }
    // print("Distance: "+distance);
      
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      
        /*foreach(GameObject penguin in funHunters){
    
        distance = Vector3.Distance(this.transform.position, penguin.transform.position);
        //Debug.Log(distance);
        penguinScanned = penguin.GetComponent<Penguin>();
        if((distance < closestHunterDistance) && (penguinScanned.isfishing().Equals(false))){
            print("fishing: "+penguinScanned.imFishing);
           closestHunter = penguinScanned;
           closestHunterDistance = distance;

    }
    }
      */  
    }
}


