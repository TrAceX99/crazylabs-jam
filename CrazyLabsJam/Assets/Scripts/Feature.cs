using UnityEngine;

public class Feature : MonoBehaviour {
    public Customizable segment;

    protected bool active;

    protected ParticleSystem effect;

    protected virtual ToolType UsedTool { get { return ToolType.None; } }
    
    private void Awake() {
        active = true;
        effect = GetComponentInChildren<ParticleSystem>();
    }

    protected virtual void Start() {
        GameManager.Instance.player.OnToolChange.AddListener(ToolChangeHandle);
    }


    public virtual void Done() {
        segment.FeatureDone();
        active = false;
    }

    protected void ToolChangeHandle() {
        if (GameManager.Instance.player.SelectedTool == UsedTool) {
            effect.Play();
        } else {
            effect.Stop();
        }
    }

    public virtual void HandleTouch(Touch touch) { }
    public virtual void HandleTap() { }
}