using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager> {

    public MenuController menuController {get; private set;}


    public void Start(){
        this.menuController = this.GetComponentInChildren<MenuController>(true);
    }
    
}