using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolechangerpopup : MonoBehaviour
{
    // public Animator animator;
    public GameObject rcpopup;

    // public void popup(){
    //     animator.SetBool("Rolechange", true);
    // }
    // public void popdown(){
    //     animator.SetBool("Rolechange", false);
    //     print("button pressed");
    // }

    public void OpenPanel()
    {
        rcpopup.SetActive(false);
        if (rcpopup != null)
        {
            rcpopup.SetActive(true);
        }
    }

}
