using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcChoosePop : MonoBehaviour
{
    public Canvas canvas;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = canvas.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YesButt(){
        animator.SetBool("RcBool", true);
    }
    public void NoButt()
    {
       animator.SetBool("RcBool", false);
       animator.SetBool("testbool", false);
    }
}
