using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
Fish counter used to track the total number of fish 
and is attached to to number of fish displayed at textMeshPro
on the canvas. When the int number of fish changes, 
so does the text displayed.
@author Sasha Buskin
*/
public class FishCounter : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject num ;
    public TextMeshProUGUI text;
    public int fishNum;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = fishNum.ToString();
    }

    // function to set new empire funds, used by BuildingManager Script
    public void setEmpireFunds(int amount) => this.fishNum = amount;

    // function to send empire funds data to BuildingManager Script
    public int getEmpireFunds() => this.fishNum;
}