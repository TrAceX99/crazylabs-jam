using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    public ToolType toolType;
    public CustomizationSet set;
    public int optionIndex;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnComponentClick(){
        Debug.Log(this.toolType);
        if(this.set != null && this.optionIndex != -1){
            this.set.ApplyOption(this.optionIndex);
        } else {
            GameManager.Instance.player.selectedTool = this.toolType;
        }

    }
}
