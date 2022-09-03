using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IglooPopup : MonoBehaviour
{
    /*
    IglooPopup class: Used for functions of the Empire Popup
                      that appears when the main Igloo is 
                      clicked. The penguin population stats
                      on the empire popup are updated in the 
                      Update function. This class also contains 
                      functions popup() & popdown() that are 
                      uset to alter bool parameters in the 
                      animator in order to provide a smooth 
                      animation in and out of the screen of both
                      the igloo popup and the X button(multidirectional transition).   
    
    @author:Sasha Buskin
    */
    public Animator animator;
    public TextMeshProUGUI penguCount;
    public EmpireObj empire;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(empire.pinguNum);
        penguCount.text = empire.pinguNum;
    }

//   popup() & popdown() functions used in onClicks and raycasts 
//   (xbutton & igloo) to transtition panel and button.
    public void popup(){
        animator.SetBool("OpenIgloo", true);
    }
    public void popdown(){
        animator.SetBool("OpenIgloo", false);
        print("button pressed");
    }
     
}
