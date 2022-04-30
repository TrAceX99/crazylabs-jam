
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllerType : MenuControllerAbstract
{

    override public void Show(CustomizationSet[] customizationSets)
    {
        if (customizationSets == null || customizationSets.Length <= 0){
            this.Hide();
            return;
        } 
        else this.componentContainerController.ShowToolSetTypes(customizationSets);

        this.gameObject.SetActive(true);

        scrollRect.horizontalNormalizedPosition = 0f;
    }

}
