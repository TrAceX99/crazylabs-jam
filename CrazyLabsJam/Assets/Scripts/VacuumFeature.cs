using UnityEngine;

public class VacuumFeature : Feature {

    protected override ToolType UsedTool { get { return ToolType.VacuumTool; } }

    public override void HandleTouch(Touch touch) {
        if (!active || GameManager.Instance.player.SelectedTool != UsedTool) return;
        if (touch.phase != TouchPhase.Moved) return;

        active = false;

        GetComponent<Animation>().Play();
        AudioManager.Instance.Play("Slurp", 0.5f);
    }

    protected override void Start() {
        base.Start();
        transform.localEulerAngles += Vector3.forward * Random.Range(0f, 360f);
    }

    void AnimationDone() {
        Done();
        Destroy(gameObject);
    }
}