using UnityEngine;

public class TapFeature : Feature {

    protected override ToolType UsedTool { get { return ToolType.TapTool; } }

    public override void HandleTap() {
        if (!segment.selected) return;
        if (!active || GameManager.Instance.player.SelectedTool != UsedTool) return;

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