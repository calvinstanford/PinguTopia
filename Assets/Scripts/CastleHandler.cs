using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CastleHandler : MonoBehaviour
{
   /*
   This script and function is attached to the Igloo game objects button component.
   It centers the camera on the object when user taps it.
   */ 

public Camera cam;
    public void CenterCamera(){
     
       Debug.Log("CenterCam");
       
       Button but  = GetComponent<Button>();
       
       Debug.Log(but.transform.position); 
       Vector3 pos = but.transform.position;
       pos.z = -10f;
       
       cam.transform.position = pos;
    }
}
