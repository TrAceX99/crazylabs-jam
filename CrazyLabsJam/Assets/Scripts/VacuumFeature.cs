using UnityEngine;

public class VacuumFeature : Feature {

    public override void HandleTouch(Touch touch) {
        if (!active || GameManager.Instance.player.selectedTool != ToolType.VacuumTool) return;
        if (touch.phase != TouchPhase.Moved) return;

        active = false;

        GetComponent<Animation>().Play();
        AudioManager.Instance.Play("Slurp");
    }

    void AnimationDone() {
        Done();
        Destroy(gameObject);
    }
}