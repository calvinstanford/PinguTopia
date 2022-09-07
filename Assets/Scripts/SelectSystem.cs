using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSystem : MonoBehaviour
{
    /*
    The SelectSystem script is used as a gameObject to store the currently user-selected penguin object. 
    
     @author Sasha Buskin
    */
    public Penguin selectedPenguin;
    public bool selectorEnabled;
    // Start is called before the first frame update
    void Start()
    {
        selectorEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
