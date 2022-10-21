using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BuildingManager : MonoBehaviour
{
    /* 
        Building Manager Class will be responsible for
        the actual selection of type of building to
        be built, time taken to build, cost to build,
        and the actual building process.
    */

    private BuildingTypeSO activeBuildingType;
    [SerializeField] int funds;

    // void start(){
    //     GameObject funds = GameObject.Find("fishNum");
    //     fishCounter = funds.GetComponent<FishCounter>();
    // }

    // void start(){
    //     fishCounter = GameObject.Find("getEmpireFunds").GetComponent<FishCounter>();
    //     funds = fishCounter.getEmpireFunds();
    // }
    // place down building
    private void Update() {

        print("Current Funds: "+funds);

        if(funds >= 10){
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && activeBuildingType != null) {
                Vector3 mouseWorldPosition = GetMouseWorldPosition();
                Instantiate(activeBuildingType.prefab, mouseWorldPosition, Quaternion.identity);

                activeBuildingType = null; // after placing down, reset active building type to null.
                funds -= 1;
            }
        }
    }

    public void setEmpireFunds(FishCounter fishCounter){
        funds = fishCounter.fishNum;
    }

    public int getEmpireFunds(){
        return funds;
        // FishCounter fishCounter = GameObject.Find("FishCounter").GetComponent<FishCounter>();
        // funds = fishCounter.getEmpireFunds();
        // return funds;
    }

    // set active building type
    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSO) {
        activeBuildingType = buildingTypeSO;
    }

    // get active building type
    public BuildingTypeSO GetActiveBuildingType() {
        return activeBuildingType;
    }

    /* Functions to get mouse pointer position */

    public static Vector3 GetMouseWorldPosition() {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = -1f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera){
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
