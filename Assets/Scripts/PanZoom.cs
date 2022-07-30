 using UnityEngine;
 using System.Collections;

/*
This script is attached to the Main camera in the main game, 
it allows the user to pan over the map by swiping their touchscreen.

Improvements to be made:
-Add pinch to zoom in/out.
-Speed adjustment.
*/

 public class PanZoom : MonoBehaviour
 {
            Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 40;
	
    public Vector3 fingerPos;
    public float speed = 0.9F;
     void Update() {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
             Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
             transform.Translate(-touchDeltaPosition.x * Time.deltaTime, -touchDeltaPosition.y * Time.deltaTime, 0);
         }

   
        if(Input.GetMouseButtonDown(0)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }else if(Input.GetMouseButton(0)){
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
	}

    void zoom(float increment){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }


    public void center(){
        print("xXXXxXXXXXXXXXxxxxxx");
        
        Vector3 pos = fingerPos;
 pos.z = -10;
 print(pos);
 Vector3 realWorldPos = Camera.main.ScreenToWorldPoint(pos);
     }
 }
 