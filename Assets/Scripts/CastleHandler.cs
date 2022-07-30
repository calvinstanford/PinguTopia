using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CastleHandler : MonoBehaviour
{
   // public GameObject button; 

public Camera cam;
    public void CenterCamera(){
     
       Debug.Log("ZZZZZZZZZZZZZZZ");
       
       Button but  = GetComponent<Button>();
       
        print(but.transform.position);
       
       Vector3 pos = but.transform.position;

       pos.z = -10f;

        cam.transform.position = pos;
    }
}
