using UnityEngine;

public class AnimationController : MonoBehaviour {
    readonly int PARAM_SUCCESS = Animator.StringToHash("Success");
    readonly int PARAM_EXIT = Animator.StringToHash("Exit");
    
    [SerializeField] ParticleSystem successEffect;

    Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void PlaySuccess() {
        anim.SetTrigger(PARAM_SUCCESS);
        successEffect.Play();
    }

    public void PlayExit() {
        anim.SetTrigger(PARAM_EXIT);
        successEffect.Play();
    }

    void EnableInput() {
        GameManager.Instance.player.inputEnabled = true;
    }

    void MonsterLeft() {
        Destroy(GameManager.Instance.monster.gameObject);
        GameManager.Instance.NewMonster();
    }
}