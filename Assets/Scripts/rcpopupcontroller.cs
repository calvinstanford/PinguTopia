using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcpopupcontroller : MonoBehaviour
{
    public Animator animu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        animu.SetBool("openrcpop", true);
    }
    public void Hide()
    {
        animu.SetBool("openrcpop", false);
    }

    // public void popup(){
    //     animu.SetBool("OpenIgloo", true);
    // }
    // public void popdown(){
    //     animu.SetBool("OpenIgloo", false);
    //     print("button pressed");
    // }
}