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

    public TextMeshProUGUI textMesh;
    private BuildingTypeSO activeBuildingType;
    private FishCounter fishCounter;
    private FishingHole fishingHole;

    // place down building
    private void Update() {
        int funds = fishCounter.fishNum;

        if(funds == 10){
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && activeBuildingType != null) {
                Vector3 mouseWorldPosition = GetMouseWorldPosition();
                Instantiate(activeBuildingType.prefab, mouseWorldPosition, Quaternion.identity);

                activeBuildingType = null; // after placing down, reset active building type to null.
                fishCounter.fishNum -= 10;
            }
        } else {
            // function to show error message here
        }
        
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
