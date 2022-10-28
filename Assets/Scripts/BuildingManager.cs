using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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
    public FishCounter fishCounter;
    public int funds;
    private int cost;
    public GameObject Notibox;
    public TextMeshProUGUI Notitext;
    public GameObject scrollView;

    // void start(){
    //     Notitext = Notibox.GetComponent<TextMeshProUGUI>();
    // }
    private void Update() {

        funds = fishCounter.getEmpireFunds();

        if(funds >= 10){
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && activeBuildingType != null) {
                Vector3 mouseWorldPosition = GetMouseWorldPosition();
                if (CanSpawnBuilding(activeBuildingType, mouseWorldPosition)){
                    Instantiate(activeBuildingType.prefab, mouseWorldPosition, Quaternion.identity);

                    fishCounter.fishNum -= 10;
                    //costToBuild();
                    activeBuildingType = null; // after placing down, reset active building type to null.


                    //funds = funds - 10; // cost to build hut taken away from funds.
                    //fishCounter.setEmpireFunds(funds); // set new empire funds. 
                } else {
                    invalidBuild();
                    activeBuildingType = null;
                }
            }
        } else if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && activeBuildingType != null) {
            insuffiecientFunds();
            activeBuildingType = null;
        }
    }


    void insuffiecientFunds(){
        Notitext = Notibox.GetComponent<TextMeshProUGUI>();
        Notitext.text = Notitext.text+"\n You're Broke, keep your money up dawg!";
        //scrollToBot();
    }

    void invalidBuild(){
        Notitext = Notibox.GetComponent<TextMeshProUGUI>();
        Notitext.text = Notitext.text+"\n Can't build there, go somewhere else m9";
        //scrollToBot();
    }

    // public void scrollToBot(){
    //     Canvas.ForceUpdateCanvases();
    //     scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
    // }

    public void costToBuild() {
        cost = 10;
        fishCounter.fishNum = funds - cost;
    }

    // set active building type
    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSO) {
        activeBuildingType = buildingTypeSO;
    }

    // get active building type
    public BuildingTypeSO GetActiveBuildingType() {
        return activeBuildingType;
    }

    // check to see if user places building down on buildable area
    private bool CanSpawnBuilding(BuildingTypeSO buildingTypeSO, Vector3 position){
        BoxCollider2D buildingBoxCollider2D = buildingTypeSO.prefab.GetComponent<BoxCollider2D>();

        if (Physics2D.OverlapBox(position + (Vector3)buildingBoxCollider2D.offset, buildingBoxCollider2D.size, 0)) {
            return false;
        } else {
            return true;
        }
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
