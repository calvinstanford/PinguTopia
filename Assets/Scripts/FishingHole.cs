using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
FishingHole Class used to control fishing event when button pressed.
Involes many different variables of the fishing function eg avaliable fish, hunters etc.
@author Sasha Buskin
*/
public class FishingHole : MonoBehaviour
{
 
    public GameObject[] funHunters;
    public List<Penguin> hunters;
    private Penguin closestHunter, penguinScanned;
    public FishCounter fishCounter;
    public PenguinPath fp;
    /*
    public void getFished(): 
    is called when the user presses the fish button and 
    finds a penguin object and triggers its goFishing() function.
    -should find nearest penguin?
    -should find only hunters. 
    */
    public void getFished(){
      
      foreach(GameObject penguin in funHunters)
      {
        fp = penguin.GetComponent<PenguinPath>();
        fp.timeSet = false;
      }
    
      Debug.Log("Water pressed");
      
      int fl = funHunters.Length;
      int a = Random.Range(0, fl);
      
      foreach (Penguin penguin in hunters)
      {
        
            print(penguin.name);
            print(penguin.imFishing);
            
            if(!penguin.imFishing){
                
                 print("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                penguin.penguinPath.AIDS.target =  penguin.fishingLocation.transform;
                penguin.iftimeset = false;
                penguin.penguinPath.navigating = false;
                penguin.goFishing();
                break;
           
            }     
      }
    }
 
    void Start()
    {
    
    }
    
    void FixedUpdate()
    {
        int fish = 0;
  
        foreach(GameObject penguin in funHunters){
      
        hunters.Add(penguin.GetComponent<Penguin>());
        penguinScanned = penguin.GetComponent<Penguin>();
       
        }
      
     
    }
      
  }