using UnityEngine;

public enum ToolType {
    None, TapTool, DragTool, VacuumTool
}

public class Player : MonoBehaviour {
    enum State {
        Main, Selected
    }

    public ToolType selectedTool;
    public bool inputEnabled;

    [SerializeField] float tapMaxDuration = 0.2f;
    [SerializeField] LayerMask segmentSelectionMask;
    [SerializeField] LayerMask featureInteractionMask;

    float tapTimer;
    State state;
    CameraController cameraController;
    public Customizable selectedSegment {get; private set;}
    Feature activeFeature;

    private void Start() {
        state = State.Main;
        selectedTool = ToolType.None;
        cameraController = Camera.main.gameObject.GetComponent<CameraController>();
    }

    private void Update() {
        if (!inputEnabled) return;

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;

            switch (touch.phase) {
                case TouchPhase.Began:
                    if (state == State.Selected) {
                        if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit, 100f, featureInteractionMask) && hit.collider.tag == "Feature") {
                            activeFeature = hit.collider.gameObject.GetComponent<Feature>();
                        }
                    }
                    tapTimer = Time.unscaledTime;
                    break;
                case TouchPhase.Moved:
                    if (state == State.Selected) {
                        if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit, 100f, featureInteractionMask) && hit.collider.tag == "Feature") {
                            hit.collider.gameObject.GetComponent<Feature>().HandleTouch(touch);
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    if (Time.unscaledTime - tapTimer < tapMaxDuration) {
                        Tap(touch.position);
                    }
                    activeFeature?.HandleTouch(touch);
                    activeFeature = null;
                    break;
                default:
                    break;
            }

            activeFeature?.HandleTouch(touch);
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
            if (!Physics.Raycast(tapRay, out hit, 100f, segmentSelectionMask)) return;

            if (hit.collider.tag == "Customizable") {
                SelectSegment(hit.collider.gameObject.GetComponent<Customizable>());
            }
        } else if (state == State.Selected) {
            if (!Physics.Raycast(tapRay, out hit, 100f, featureInteractionMask)) return;

            if (hit.collider.tag == "Feature") hit.collider.gameObject.GetComponent<Feature>().HandleTap();
        }
    }

    void SelectSegment(Customizable segment) {
        state = State.Selected;
        selectedSegment = segment;
        segment.Select();
    }

    public void DeselectSegment() {
        state = State.Main;
        selectedSegment.Deselect();
        selectedSegment = null;
        selectedTool = ToolType.None;
    }
}