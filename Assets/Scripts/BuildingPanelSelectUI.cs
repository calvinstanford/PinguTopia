using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanelSelectUI : MonoBehaviour
{
    /* 
        BuildingPanelSelectUI Class will be responsible for
        generating build panel UI.

        Will print duplicates of button template game object.
        Number of duplicates will be determined by number of 
        different building types (prefabs) set in Unity Editor.

        Also responsible for setting Active Building Type Selected 
        data for the Building Manager Script to manipulate.
    */
    [SerializeField] private List<BuildingTypeSO> buildingTypeSOList;
    private BuildingManager buildingManager;

    private Dictionary<BuildingTypeSO, Transform> buildingBtnDictionary;

    private void Awake() {
        Transform buildingBtnTemplate = transform.Find("buildingBtnTemplate");
        buildingBtnTemplate.gameObject.SetActive(false);

        buildingBtnDictionary = new Dictionary<BuildingTypeSO, Transform>();

        int index = 0;
        foreach (BuildingTypeSO buildingTypeSO in buildingTypeSOList){
            Transform buildingBtnTransform = Instantiate(buildingBtnTemplate, transform);
            buildingBtnTransform.gameObject.SetActive(true);

            buildingBtnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * 60, 0);
            buildingBtnTransform.Find("image").GetComponent<Image>().sprite = buildingTypeSO.sprite;

            buildingBtnTransform.GetComponent<Button>().onClick.AddListener(() => {
                buildingManager.SetActiveBuildingType(buildingTypeSO);
                UpdateSelectedVisual();
            });

            buildingBtnDictionary[buildingTypeSO] = buildingBtnTransform;

            index++;
        }
    }

    private void Start() {
        UpdateSelectedVisual();
    }

    private void UpdateSelectedVisual() {
        foreach (BuildingTypeSO buildingTypeSO in buildingBtnDictionary.Keys) {
            buildingBtnDictionary[buildingTypeSO].Find("selected").gameObject.SetActive(false);
        }

        BuildingTypeSO activeBuildingType = buildingManager.GetActiveBuildingType();
        buildingBtnDictionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
    }
}
