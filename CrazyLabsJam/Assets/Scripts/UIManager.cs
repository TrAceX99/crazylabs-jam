using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager> {

    public MenuController menuController {get; private set;}


    override public void Awake(){
        base.Awake();
        this.menuController = this.GetComponentInChildren<MenuController>();
    }
    
}