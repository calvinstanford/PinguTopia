using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


/*
FishingPath to handle the pathfinding and path that penguins follow to go fishing.
Handles animation on the path and also handles the fishing animation and initiates the fishing
system, including a times and fish counter that will increase randomly, speed dependant on level.
*/


public class FishingPath : MonoBehaviour
{
    // Start is called before the first frame update
    public Penguin penguin;
    public AIPath fishingPath;
    public Animator animator;
    public bool timeSet;
    void Start()
    {
        animator = GetComponent<Animator>();
        fishingPath = GetComponent<AIPath>();
        penguin = GetComponent<Penguin>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fishingPath.canMove)
        {       
            
                animator.SetFloat("Speed", 3);
                animator.SetFloat("Horizontal", fishingPath.desiredVelocity.x);
                animator.SetFloat("Vertical", fishingPath.desiredVelocity.y);
                fishingPath.OnTargetReached();
       

        };
        if(fishingPath.reachedEndOfPath){
            
        penguin.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        penguin.animatorWalk.SetBool("Fish", true);
        penguin.imFishing = true;
        
        
        if (timeSet == false){
            float randomTime = Random.Range(15f,50f);
            penguin.fishTime = randomTime;
    }       timeSet = true;
        }
    } 
    
    
}
