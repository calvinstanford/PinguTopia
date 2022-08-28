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
    private Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 40;
 
    /*void Update: Update function handles camera movement with 
                   one finger and calls the zoom function when 
                   two fingers are touching the screen.
    
    
    */
    void Update() {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
             Debug.Log("hahahaha");
             Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
             transform.Translate(-touchDeltaPosition.x * Time.deltaTime, -touchDeltaPosition.y * Time.deltaTime, 0);
         }

   
        if(Input.GetMouseButtonDown(0)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("hahahaha2");
        }
        if(Input.touchCount == 2){
            Debug.Log("hahahaha3");
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

    /*
    public void zoom: zoom function to be called in Update.
    */
    public void zoom(float increment){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    
    }


   
 }
  