using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcchooserolepopup : MonoBehaviour
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
        yesbutton();
    }

    public void yesbutton(){
        if(Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
               print(hit.collider);
               if (hit.collider != null ){
                    Debug.Log( hit.collider.name );
                   
                if (hit.collider.gameObject.GetComponent<RoleChangeIgloo>()){
                animator.SetBool("chooserole", true);
               }
               }  
                Vector3 mousePosition = Input.mousePosition;
                print(mousePosition);
            }
        else{
            animator.SetBool("openrc", false);
        }
    }
    public void iglooXButt(){
       animator.SetBool("chooserole", false);
    }
}
