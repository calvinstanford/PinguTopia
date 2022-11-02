using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmpireUI : MonoBehaviour
{
    //public Text pinguBabyText;
    public TMP_Text pingusCountText;
    public TMP_Text huntersCountText;
    public TMP_Text nurturersCountText;

    public EmpireObj empire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pingusCountText.text = empire.pingusCount.ToString();
        huntersCountText.text = empire.huntersCount.ToString();
        nurturersCountText.text = empire.nurturersCount.ToString();
    }
}
