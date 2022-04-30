using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuControllerAbstract : MonoBehaviour
{
    protected ComponentContainerController componentContainerController;

    public void Awake(){
        this.componentContainerController = this.GetComponentInChildren<ComponentContainerController>();
        this.Hide();
    }



    public void Hide(){
        this.gameObject.SetActive(false);
    }


    public virtual void Show(CustomizationSet[] customizationSets){

    }

    public virtual void Show(CustomizationSet customizationSets){
        
    }


    public virtual void Show(){
        
    }
}
