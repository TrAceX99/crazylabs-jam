using UnityEngine;

public class Player : MonoBehaviour {
    enum State {
        Main, Feature
    }

    [SerializeField] float tapMaxDuration = 0.2f;

    float tapTimer;
    State state;
    CameraController cameraController;
    Feature selectedFeature;

    private void Start() {
        state = State.Main;
        cameraController = Camera.main.gameObject.GetComponent<CameraController>();
    }

    private void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    tapTimer = Time.unscaledTime; 
                    break;
                case TouchPhase.Ended:
                    if (Time.unscaledTime - tapTimer < tapMaxDuration) {
                        Tap(touch.position);
                    }
                    break;
                default:
                    break;
            }
        }

        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) tapTimer = Time.unscaledTime;
        if (Input.GetMouseButtonUp(0)) {
            if (Time.unscaledTime - tapTimer < tapMaxDuration) {
                Tap(Input.mousePosition);
            }
        }
        #endif

    }

    void Tap(Vector2 touchPos) {
        Ray tapRay = Camera.main.ScreenPointToRay(touchPos);
        RaycastHit hit;

        if (state == State.Main) {
            if (!Physics.Raycast(tapRay, out hit)) return;

            if (hit.collider.tag == "Feature") {
                SelectFeature(hit.collider.gameObject.GetComponent<Feature>());
            }
        } else if (state == State.Feature) {
            if (!Physics.Raycast(tapRay, out hit)) DeselectFeature();
        }
    }

    void SelectFeature(Feature feature) {
        state = State.Feature;
        selectedFeature = feature;
        feature.Select();
    }

    void DeselectFeature() {
        state = State.Main;
        selectedFeature.Deselect();
        selectedFeature = null;
    }
}