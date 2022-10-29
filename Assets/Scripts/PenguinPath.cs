using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/*
PenguinPath to handle the pathfinding and path that penguins follow to go fishing and when custom navigating.
Handles animation on the path and also handles the fishing animation and initiates the fishing
system, including a times and fish counter that will increase randomly, speed dependant on level.
*/


public class PenguinPath : MonoBehaviour
{
    // Start is called before the first frame update
    public Penguin penguin;
    public AIPath penguinPath;
    public Animator animator;
    public bool timeSet;
    public SelectSystem seleSys;
    public bool navigating = false;
    public Touch touch;
    public float waitTime = 5;
    public bool penguinDetected;
    public AIDestinationSetter AIDS;
    public bool XButDetected = false;
    public bool deselected;
    public bool penguinHit = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        penguinPath = GetComponent<AIPath>();
        penguin = GetComponent<Penguin>();
        AIDS = GetComponent<AIDestinationSetter>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (seleSys.selectedPenguin != null && navigating == true){

            if(Input.GetMouseButtonDown(0)){
                
               RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
               print(hit.collider);
               if (hit.collider != null ){
                 
                    print("okfosar((((-----------------------------");
                    Debug.Log( hit.collider.name );
                
                }
                
                if (!XButDetected && navigating && !penguinHit){
                    
                    if(waitTime != 5){
                        waitTime = 5;
                    }
                }
                
                seleSys.selectedPenguin.idle = false;
                seleSys.selectedPenguin.destination.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                seleSys.selectedPenguin.aIDestinationSetter.target =  seleSys.selectedPenguin.destination.transform;
                seleSys.selectedPenguin.penguinAIPath.canMove = true;
                penguinHit = true;
            }
            
        }
        
        if(penguinPath.canMove && !penguinPath.reachedEndOfPath)
        {       
                print("PATHING ANIMATION");
                animator.SetFloat("Speed", 3);
                animator.SetFloat("Horizontal", penguinPath.desiredVelocity.x);
                animator.SetFloat("Vertical", penguinPath.desiredVelocity.y);
                penguinPath.OnTargetReached();
       
        };
          
        if(penguinPath.reachedEndOfPath && !deselected){
            
            animator.SetFloat("Speed", 0);
            if(penguinPath.desiredVelocity.x > 0 && penguinPath.desiredVelocity.y > 0){
                animator.SetInteger("StoppingDirection 0", 4);//right
            print("11");//up
            }
            if(penguinPath.desiredVelocity.x > 0 && penguinPath.desiredVelocity.y < 0){
            animator.SetInteger("StoppingDirection 0", 2);//down
            print("22");//down
            }
            if(penguinPath.desiredVelocity.x < 0 && penguinPath.desiredVelocity.y > 0){
            animator.SetInteger("StoppingDirection 0", 1);//up
            print("33");//right
            }
            if(penguinPath.desiredVelocity.x < 0 && penguinPath.desiredVelocity.y < 0){
            animator.SetInteger("StoppingDirection 0", 3);//left
            print("44");//left
            }
            

            if(waitTime > 0){            
                
                print(waitTime);
                waitTime -= Time.deltaTime;            
            }
            if(waitTime < 0){
                
                penguin.idle = true;
                penguinPath.canMove = false;
            }

        }
        
    
        if(navigating == false && penguinPath.reachedEndOfPath){
          
            if (timeSet == false){
                print("DA TIME FALSEEEEEEEE");
                penguin.imFishing = true;
                penguin.rb.constraints = RigidbodyConstraints2D.FreezeAll; 
                penguin.animatorWalk.SetBool("Fish", true);
                float randomTime = Random.Range(15f,26f);
                penguin.fishTime = randomTime;
                timeSet = true;
            } 
            if (timeSet == true){
                print("DA TIME TRUEEEEEEEEEEEEE");
            }
        } 
   

    }
}