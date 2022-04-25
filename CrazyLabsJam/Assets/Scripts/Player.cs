using UnityEngine;

public class Player : MonoBehaviour {
    enum State {
        Main, Selected
    }

    [SerializeField] float tapMaxDuration = 0.2f;

    float tapTimer;
    State state;
    CameraController cameraController;
    Customizable selectedSegment;

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

            if (hit.collider.tag == "Customizable") {
                SelectSegment(hit.collider.gameObject.GetComponent<Customizable>());
            }
        } else if (state == State.Selected) {
            if (!Physics.Raycast(tapRay, out hit)) DeselectSegment();
        }
    }

    void SelectSegment(Customizable segment) {
        state = State.Selected;
        selectedSegment = segment;
        segment.Select();
    }

    void DeselectSegment() {
        state = State.Main;
        selectedSegment.Deselect();
        selectedSegment = null;
    }
}