using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    
    private GameObject currentSelectedComponent;
    private Vector2 originalPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.currentSelectedComponent != null){
            this.currentSelectedComponent.transform.position = Input.mousePosition;
        }
    }

    public void OnComponentClick(GameObject clickedComponent){
        if(this.currentSelectedComponent != null){
            var component = this.currentSelectedComponent;
            this.currentSelectedComponent = null;
            component.transform.position = this.originalPosition;
        }
        this.originalPosition = clickedComponent.transform.position;
        this.currentSelectedComponent = clickedComponent;
        
    }
}
