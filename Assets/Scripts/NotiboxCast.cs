using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NotiboxCast : MonoBehaviour
{
    /*
    NotiboxCast script attached to Canvas to provide Graphic Raycast 
    function in order to prevent camera movement 
    when touch is detected on the NotificationBoxHUD.

    Used in PanZoom.
    @author Sasha Buskin 
    */
    GraphicRaycaster gr;
    PointerEventData ped;
    EventSystem m_EventSystem;
    List<RaycastResult> results;

    public SelectSystem seleSys;
    
    // Start is called before the first frame update
    void Start()
    {
        gr = this.GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();

    }

    // Update is called once per frame
    void Update()
    {
    results = new List<RaycastResult>();
    }
   
   /*public bool notiBoxDetected(bool input):   Graphics raycast function attached to the Canvas 
                                                that returns true if the user touches the notification box 
                                                UI through graphic raycast (and false if not), used to
                                                stop camera panning if user touches notifbox.
                                                */
    public bool notiBoxDetected(bool input){

        if(input == true){
            
            ped = new PointerEventData(m_EventSystem);
            ped.position = Input.mousePosition;
            gr.Raycast(ped, results); 
            
            foreach (RaycastResult result in results){
                
                if(result.gameObject.name.Equals("NotificationBoxHUD")){
                    
                    print("true");
                    return true;                    
                }
                Debug.Log("Hit " + result.gameObject.name);
                if(result.gameObject.name.Equals("StatXBut")){
                    seleSys.selectedPenguin.penguinPath.XButDetected = true;
                    seleSys.selectedPenguin.penguinPath.navigating = false;
                                     print("theassman");
                }
            }                
           
            return false;            
        }
        else{
           
          
            return false;
        }
    }
}

