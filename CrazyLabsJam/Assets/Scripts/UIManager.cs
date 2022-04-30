using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager> {

    public MenuController menuController {get; private set;}
    public MenuControllerType menuControllerType {get; private set;}
    public BackButtonController backButton {get; private set;}
    public NextMonsterButton nextMonsterButton {get; private set;}

    public int segmentCounter;

    public void Start(){
        this.menuController = this.GetComponentInChildren<MenuController>(true);
        this.menuControllerType = this.GetComponentInChildren<MenuControllerType>(true);
        this.backButton = this.GetComponentInChildren<BackButtonController>(true);
        this.nextMonsterButton = this.GetComponentInChildren<NextMonsterButton>(true);
        segmentCounter = 0;
    }
    

    public void HideMenu(){
        this.menuController.Hide();
        this.menuControllerType.Hide();
        this.backButton.Hide();
    }

    public void ShowMenu(CustomizationSet[] CustomizationSets = null){
        if(CustomizationSets != null){
            this.menuControllerType.Show(CustomizationSets);
        }
        this.menuController.Show();
        this.backButton.Show();
    }


    public void ShowToolsSet(CustomizationSet CustomizationSet){
        this.menuController.Show(CustomizationSet);
        this.backButton.Show();
    }

    public void ShowCustomizationItemsMenu(CustomizationSet CustomizationSet){
        this.menuController.Show(CustomizationSet);

    }

    public void ShowNextMonsterButton(){
        segmentCounter++;
        if (segmentCounter >= 2) {
            this.nextMonsterButton.Show();
            GameManager.Instance.monster.HappyFace();
        }
    }

    public void ResetNextMonster() {
        segmentCounter = 0;
        this.nextMonsterButton.Hide();
    }
}