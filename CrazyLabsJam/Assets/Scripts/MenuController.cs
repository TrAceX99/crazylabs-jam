using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private ComponentContainerController componentContainerController;

    public void Awake(){
        this.componentContainerController = this.GetComponentInChildren<ComponentContainerController>();
        this.Hide();
    }



    public void Hide(){
        this.gameObject.SetActive(false);
    }


    public void Show(CustomizationSet[] customizationSets=null){
        if(customizationSets==null)   this.componentContainerController.ShowToolsBasic();
        else            this.componentContainerController.ShowTools(customizationSets);

        this.gameObject.SetActive(true);

    }
}
