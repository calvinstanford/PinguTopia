
//TO BE USED IN RAYCASTING IN FUTURE DEVELOPMENT


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScanner : MonoBehaviour
{ 
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5f;
            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition); 
            Collider2D[] col = Physics2D.OverlapPointAll(v, 0, -Mathf.Infinity, Mathf.Infinity);

            if(col.Length > 0){
                foreach(Collider2D c in col)
                {
                    print("please");
                    //Debug.Log("Collided with: " + c.collider2D.gameObject.name);
                    print(c.gameObject.name);
                }
        }
        }
    }
 } 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 /* // Start is called before the first frame update
    
    public GameObject fHole;
    public FishingHole fishingHole;
    private Ray ray;
    private RaycastHit hit;
    void Start()
    {
        
    }

    // Update is called once per frame
   
       
        {    
        
         
         
         if (Input.GetMouseButtonDown(0))
         {
            print("hahahahahaha");
            
    
        
        {
            print("jfjfjfjfjfjf");
             // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, transform.forward);
        print(Input.mousePosition);
        // If it hits something...
        
        if (hit.collider != null)
                 Debug.Log("Button Clicked");
                 print(hit.collider.name);
                 fHole = hit.collider.gameObject;
                
                fishingHole = fHole.GetComponent<FishingHole>();
                fishingHole.getFished();
                print(fishingHole.funHunters.Length);
             }
         } 

          if (Input.GetMouseButtonDown(0))
    {
        print("Clicked");
        Vector2 touch = Input.mousePosition;
        
        
        
        bool hit = Physics.Raycast(Input.mousePosition, transform.forward);
        print("Touch position"+touch);
        print("Forward"+transform.forward);
        
         if (hit. != null)
        {
            print("hit.collider != null");
            if (hit.transform.gameObject.name == "goFish")
            {
                print(hit.transform.gameObject.name);
            }
        }
        else
            {
                print("hit.collider == null");
                
            }
    }
            
        }
    }
}*/ 
