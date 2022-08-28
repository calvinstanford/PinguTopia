using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
}
