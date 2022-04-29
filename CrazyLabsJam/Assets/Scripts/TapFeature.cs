using UnityEngine;

public class TapFeature : Feature {
    public override void HandleTap() {
        if (!active || GameManager.Instance.player.selectedTool != ToolType.TapTool) return;

        active = false;

        GetComponent<Animation>().Play();
    }

    void AnimationDone() {
        Done();
        Destroy(gameObject);
    }

    void PlaySFX() {
        AudioManager.Instance.Play("Pop");
    }
}