using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMonsterButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.Hide();
    }


    public void Hide(){
        this.gameObject.SetActive(false);
    }

    public void Show(){
        this.gameObject.SetActive(true);
    }

    public void NextMonster(){
        GameManager.Instance.Done();
        this.Hide();
    }
}
