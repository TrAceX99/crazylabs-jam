using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    


    public void BackButtonPressed(){
        Debug.Log("test");
        GameManager.Instance.player.DeselectSegment();
    }
}