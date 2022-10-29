using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectSystem : MonoBehaviour
{
    /*
    The SelectSystem script is used as a gameObject to store the currently user-selected penguin object. 
    
     @author Sasha Buskin
    */
    public Penguin selectedPenguin;
    public bool selectorEnabled;
    public Animator animatorPopup;
    public TextMeshProUGUI fishLvlText;
    public TextMeshProUGUI nurtureLvlText;
    public TextMeshProUGUI combatLvlText;
    public TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        selectorEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        PenguinSelector();
    }
   
    /*
public void PenguinSelector(): This function will run in Update(). If the system selector is enabled, 
                               this function detects touch and creates a raycast2d to detect specifically 
                               Penguin objects. It then begins the statbox popup animation, saves the 
                               clicked penguin object in the selectsystem, display a pointer over the seleted penguin,
                               and sets SelectSys.selectorEnabled = false; which disables the bug of selecting 
                               multiple. This is changed back to true when closing the statbox popup.
*/  
   
    public void PenguinSelector(){
    
        if(selectorEnabled == true){
    
                if(Input.GetMouseButtonDown(0)){
                
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                print(hit.collider);
                
                    if (hit.collider != null ){
                        
                        print("okfosar((((-----------------------------");
                        Debug.Log( hit.collider.name );
                    
                        if (hit.collider.gameObject.GetComponent<Penguin>()){
                            

                            if(selectedPenguin != null){
                                selectedPenguin.pointer.pointerDeselect();
                                selectedPenguin.penguinPath.penguinHit = true;
                                
                                selectedPenguin = null;
                            }
                            
                            selectedPenguin = hit.collider.gameObject.GetComponent<Penguin>();
                            selectedPenguin.penguinPath.navigating = true;
                            fishLvlText.text = selectedPenguin.fishingLevel.ToString();
                            nurtureLvlText.text = selectedPenguin.nurtureLevel.ToString();
                            combatLvlText.text = selectedPenguin.combatLevel.ToString();
                            nameText.text = selectedPenguin.name;
                            print("its a penguin!!!!!!");
                            animatorPopup.SetBool("OpenStat", true);
                        // selectorEnabled = false;
                    
                            print("OOOOOOOOOOOZE");
                            
                            if(!selectedPenguin.pointer.pointerArrow.gameObject.activeInHierarchy){
                                
                                selectedPenguin.pointer.pointerSelect();
                            }
                        }                
                    }  
                    Vector3 mousePosition = Input.mousePosition;
                    print(mousePosition);

                }
        }
    
    }
    
    public void closeStats(){
        
        animatorPopup.SetBool("OpenStat", false);
        selectedPenguin.pointer.pointerDeselect();
        selectedPenguin.penguinPath.deselected = true;
        selectedPenguin.penguinPath.navigating = false;
        selectedPenguin.idle = true;
        selectedPenguin.penguinAIPath.canMove = false;
        selectedPenguin.penguinPath.AIDS.target =  selectedPenguin.fishingLocation.transform;
       
        if(selectedPenguin.imFishing){
            selectedPenguin.imFishing = false;      
        }
        
        selectedPenguin = null;
        selectorEnabled = true;
        

    }
}
