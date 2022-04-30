using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager> {

    public MenuController menuController {get; private set;}
    public BackButtonController backButton {get; private set;}
    public NextMonsterButton nextMonsterButton {get; private set;}


    public void Start(){
        this.menuController = this.GetComponentInChildren<MenuController>(true);
        this.backButton = this.GetComponentInChildren<BackButtonController>(true);
        this.nextMonsterButton = this.GetComponentInChildren<NextMonsterButton>(true);
    }
    

    public void HideMenu(){
        this.menuController.Hide();
        this.backButton.Hide();
    }



    public void ShowMenu(){
        this.menuController.Show();
        this.backButton.Show();
    }


    public void ShowMenu(CustomizationSet[] CustomizationSets){
        this.menuController.Show(CustomizationSets);
        this.backButton.Show();
    }

    public void ShowNextMonsterButton(){
        this.nextMonsterButton.Show();
    }
}