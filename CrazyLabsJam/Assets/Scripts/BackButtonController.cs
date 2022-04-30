using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    public void Awake(){
        this.Hide();
    }


    public void BackButtonPressed(){
        Debug.Log("test");
        GameManager.Instance.player.DeselectSegment();
    }



    public void Hide(){
        this.gameObject.SetActive(false);
    }

    public void Show(){
        this.gameObject.SetActive(true);
    }
}
