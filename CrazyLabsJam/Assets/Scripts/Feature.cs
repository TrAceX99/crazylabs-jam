using UnityEngine;

public class Feature : MonoBehaviour {
    public Customizable segment;

    protected bool active;
    
    private void Awake() {
        active = true;
    }

    public virtual void Done() {
        segment.FeatureDone();
        active = false;
    }

    public virtual void HandleTouch(Touch touch) { }
    public virtual void HandleTap() { }
}