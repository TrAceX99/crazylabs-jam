using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnComponentClick(GameObject clickedComponent){
        Debug.Log("Clicked");
        
    }
}
