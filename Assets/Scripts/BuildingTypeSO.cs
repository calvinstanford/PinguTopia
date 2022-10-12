using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BuildingTypeSO : ScriptableObject {
    public Transform prefab; // field to set building prefab
    public Sprite sprite; // field to set building sprite

    public BuildingTypeSO(Sprite sprite) => this.sprite = sprite;
}
