using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPanelManager : MonoBehaviour
{
    /* 
        Building Panel Manager Class attached to Build Button

        Used to open build panel when build button is clicked.
    */
    public GameObject OpenBuildPanel;
    public void OpenPopup() {
        if (OpenBuildPanel != null) {
            bool isActive = OpenBuildPanel.activeSelf;
            OpenBuildPanel.SetActive(!isActive);
        }
    }
}
