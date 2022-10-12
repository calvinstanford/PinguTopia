using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HutPanelManager : MonoBehaviour
{
    /*
        Hut Manager Class will be responsible for
        unit production & population cap.
    */

    public GameObject OpenHutPanel;

    public void OpenPopup() {
        if (OpenHutPanel != null) {
            bool isActive = OpenHutPanel.activeSelf;
            OpenHutPanel.SetActive(!isActive);
        }
    }
}
