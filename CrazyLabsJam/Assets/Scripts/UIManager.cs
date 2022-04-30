using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager> {

    public MenuController menuController {get; private set;}
    public BackButtonController backButton {get; private set;}


    public void Start(){
        this.menuController = this.GetComponentInChildren<MenuController>(true);
        this.backButton = this.GetComponentInChildren<BackButtonController>(true);
    }
    

    public void HideMenu(){
        this.menuController.Hide();
        this.backButton.gameObject.SetActive(false);
    }



    public void ShowMenu(){
        this.menuController.Show();
        this.backButton.gameObject.SetActive(true);
    }


    public void ShowMenu(CustomizationSet[] CustomizationSets){
        this.menuController.Show(CustomizationSets);
        this.backButton.gameObject.SetActive(true);
    }
}