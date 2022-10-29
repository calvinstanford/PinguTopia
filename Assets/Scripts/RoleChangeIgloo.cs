using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleChangeIgloo : MonoBehaviour
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
        if(Input.GetMouseButtonDown(0))
             {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
               print(hit.collider);
               if (hit.collider != null ){
                    Debug.Log(hit.collider.name );
                   
                if (hit.collider.gameObject.GetComponent<RoleChangeIgloo>()){
                animator.SetBool("RoleChanger", true);
               }
               }  
                Vector3 mousePosition = Input.mousePosition;
                print(mousePosition);

                        }
        
                    }
    public void iglooXButt(){
       animator.SetBool("RoleChanger", false);
    }
}
