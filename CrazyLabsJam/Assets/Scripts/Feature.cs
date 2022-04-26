using UnityEngine;

public class Feature : MonoBehaviour {
    public Customizable segment;

    public void Done() {
        segment.FeatureDone();
    }
}