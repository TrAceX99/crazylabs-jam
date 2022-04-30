using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    public ToolType toolType;
    public CustomizationSet set;
    public int optionIndex;

    public void OnComponentClick(){
        if(this.set != null && this.optionIndex != -1){
            this.set.ApplyOption(this.optionIndex);
        } 
        else if(this.set != null && this.optionIndex == -1){
            UIManager.Instance.ShowToolsSet(this.set);
        } 
        else {
            GameManager.Instance.player.SelectedTool = this.toolType;
        }

    }
}
