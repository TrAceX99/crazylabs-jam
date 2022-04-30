using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ComponentContainerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftArrowPrefab;
    public GameObject rightArrowPrefab;
    public GameObject componentPrefab;
    public GameObject backButtonPrefab;
    public Sprite needleSprite;
    public Sprite tweezersSprite;
    public Sprite vacuumCleanerSprite;
    public float startingPosition = 300f;
    private float nextComponent;
    void Start()
    {
        this.nextComponent = this.startingPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void initializeMenu(){
        this.nextComponent = this.startingPosition;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


        GameObject leftArrow = Instantiate(leftArrowPrefab);
        leftArrow.transform.SetParent(this.transform, false);
        leftArrow.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(15, 0, 0);

        GameObject rightArrow = Instantiate(rightArrowPrefab);
        rightArrow.transform.SetParent(this.transform, false);
        rightArrow.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-15, 0, 0);


        // GameObject backButton = Instantiate(backButtonPrefab);
        // backButton.transform.SetParent(this.transform, false);
        // backButton.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(200, 0, 0);
        
    }


    public void ShowTools(CustomizationSet[] customizationSets)
    {
        Debug.Log("Show custom");

        this.initializeMenu();
        foreach (CustomizationSet set in customizationSets)
        {
            int index = 0;
            foreach(CustomizationSet.CustomizationOption option in set.Options){
                GameObject component = Instantiate(componentPrefab);
                
                component.GetComponent<ComponentController>().set = set;
                component.GetComponent<ComponentController>().optionIndex = index;
                component.transform.SetParent(this.transform, false);
                component.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(this.nextComponent, 0, 0);
                component.GetComponent<Image>().sprite = option.icon;
                this.nextComponent += this.startingPosition;
                index++;
            }
            
        }
    }


    public void ShowToolsBasic()
    {
        Debug.Log("Show basic");

        this.initializeMenu();
        foreach (ToolType toolType in Enum.GetValues(typeof(ToolType)))
        {
            if(toolType == ToolType.None) continue;
            
            GameObject component = Instantiate(componentPrefab);
            component.GetComponent<ComponentController>().toolType = toolType;
            component.transform.SetParent(this.transform, false);
            component.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(this.nextComponent, 0, 0);
            this.nextComponent += this.startingPosition;


            if(toolType == ToolType.TapTool){
                component.GetComponent<Image>().sprite = this.needleSprite;
            } else if(toolType == ToolType.DragTool){
                
                component.GetComponent<Image>().sprite = this.tweezersSprite;
            } else if(toolType == ToolType.VacuumTool){
                
                component.GetComponent<Image>().sprite = this.vacuumCleanerSprite;
            }
        }

    }
}