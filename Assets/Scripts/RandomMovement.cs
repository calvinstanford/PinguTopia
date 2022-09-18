using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
/*
Random movement class for the NPCs to wander around map.
@author Sasha Buskin
*/
public class RandomMovement : MonoBehaviour
{ 
public float moveSpeed,direction;
private Rigidbody2D rb;
public bool isWalking;
public float walkTime, walkCounter, waitTime, waitCounter;
private int WalkDirection;
public Animator animator;
private Penguin peng;
private AIPath fishingPath;

/*
void Start: The RigidBody2d object is initialised,
            the walk and wait times are set to random lengths between 2 and 10 seconds, 
            counters are initialised,
            animator is initialised
            and ChooseDirection method called to set initial direction.
*/

void Start(){
    
    fishingPath = GetComponent<AIPath>();
    rb = GetComponent<Rigidbody2D>();
    peng = GetComponent<Penguin>();
    waitTime = Random.Range(2, 10);
    walkTime = Random.Range(2, 10);
    waitCounter = waitTime;
    walkCounter = walkTime;
    animator = GetComponent<Animator>();
    ChooseDirection();
}

/*
void Update: Deals with animation changes throughout.
             Walk counter will start.
             Random direction Vectior2 will be created and used in the switch to use the appropriate animations/movement.
             Also handles waiting and sets the direction appropriate idle asset.
            
*/

void Update(){

if(!peng.fishingPath.canMove){
    if(peng.isIdle() == true){
        if(isWalking)
        {
            animator.SetFloat("Speed", 2);
            walkCounter -= Time.deltaTime;
            
            direction = Random.Range(0, 5);
            
            
            switch(WalkDirection)
            {
                case 0:
                    animator.SetFloat("Horizontal", direction);
                    animator.SetFloat("Vertical", moveSpeed);
                    rb.velocity = new Vector2(direction, moveSpeed);
                    animator.SetInteger("StoppingDirection 0", 1);

                    break;
                case 1:
                    animator.SetFloat("Horizontal", moveSpeed);
                    animator.SetFloat("Vertical", direction);
                    rb.velocity = new Vector2(moveSpeed, direction);
                    animator.SetInteger("StoppingDirection 0", 4);
                    break;    
                case 2:
                    animator.SetFloat("Horizontal", direction);
                    animator.SetFloat("Vertical", -moveSpeed);
                    rb.velocity = new Vector2(direction, -moveSpeed);
                    animator.SetInteger("StoppingDirection 0", 2);
                    break;
                case 3:
                    animator.SetFloat("Horizontal", -moveSpeed);
                    animator.SetFloat("Vertical", direction);
                    rb.velocity = new Vector2(-moveSpeed, direction);
                    animator.SetInteger("StoppingDirection 0", 3);
                    break;
                

            }
            if(walkCounter<0)
            {
                animator.SetFloat("Speed", 0);
                waitTime = Random.Range(2, 10);
                walkTime = Random.Range(2, 10);
                isWalking = false;
                waitCounter = waitTime;
            }
        }
    else
    {
        waitCounter -= Time.deltaTime;
    rb.velocity = Vector2.zero;

        if(waitCounter<0)
        {
            ChooseDirection();
        }
    }
    }
}
}


public void ChooseDirection(){
    WalkDirection = Random.Range(0,4);
    isWalking = true;
    walkCounter = walkTime;
}


}