using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    /*
    Pointer object is used when hiding and showing a penguings pointer, 
    Every penguin has their own pointer object that is visable when penguin is seleceted.
 
 @author Sasha Buskin
    */
    public GameObject pointerArrow;
    // Start is called before the first frame update
   
    public void pointerSelect(){
        pointerArrow.SetActive(true);
    }
    public void pointerDeselect(){
        pointerArrow.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
