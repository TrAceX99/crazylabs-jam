using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuControllerAbstract : MonoBehaviour
{
    protected ComponentContainerController componentContainerController;
    protected ScrollRect scrollRect;

    public void Awake(){
        this.componentContainerController = this.GetComponentInChildren<ComponentContainerController>();
        this.scrollRect = this.GetComponent<ScrollRect>();
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
