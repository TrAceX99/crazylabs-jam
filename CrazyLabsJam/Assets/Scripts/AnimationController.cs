using UnityEngine;

public class AnimationController : MonoBehaviour {
    readonly int PARAM_SUCCESS = Animator.StringToHash("Success");
    readonly int PARAM_EXIT = Animator.StringToHash("Exit");
    
    Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void PlaySuccess() {
        anim.SetTrigger(PARAM_SUCCESS);
    }

    public void PlayExit() {
        anim.SetTrigger(PARAM_EXIT);
    }

    void EnableInput() {
        GameManager.Instance.player.inputEnabled = true;
    }

    void MonsterLeft() {
        Destroy(GameManager.Instance.monster.gameObject);
        GameManager.Instance.NewMonster();
    }
}