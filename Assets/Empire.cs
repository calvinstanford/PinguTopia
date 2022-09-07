using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Empire : MonoBehaviour
{
   
   public int penguinPop;
   public int fish;
   
   public Text fishCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fishCount.text = fish.ToString();
    }
}
