using UnityEngine;

public class DragFeature : Feature {
    [SerializeField] float pullGive = 1f;
    [SerializeField] float pullDistance = 1f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float destroyTime = 1f;

    bool grabbed = false;
    bool pulled = false;
    Plane dragPlane;
    Vector3 basePosLocal;
    Vector3 velocity;
    float destroyTimer;

    private void Start() {
        grabbed = false;
        pulled = false;
        basePosLocal = transform.localPosition;
        destroyTimer = Mathf.Infinity;
    }

    private void Update() {
        if (grabbed || !pulled) {
            velocity = Vector3.zero;
            return;
        }

        velocity += Vector3.down * gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (Time.time > destroyTimer + destroyTime) {
            Done();
            Destroy(gameObject);
        }
    }

    public override void HandleTouch(Touch touch) {
        if (!active || GameManager.Instance.player.selectedTool != ToolType.DragTool) return;

        float enter;

        switch (touch.phase)
        {
            case TouchPhase.Began:
                destroyTimer = Mathf.Infinity;
                grabbed = true;

                if (pulled) break;

                Vector3 dirVector = transform.forward;
                Vector3 camVector = Camera.main.transform.position - transform.position;
                Vector3 coplanar = Vector3.Cross(dirVector, camVector);
                Vector3 normal = Vector3.Cross(dirVector, coplanar);

                dragPlane = new Plane(normal, transform.position);
                //if (!dragPlane.GetSide(Camera.main.transform.position)) dragPlane = dragPlane.flipped;

                break;
            case TouchPhase.Moved:
                if (!grabbed) return;

                Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
                if (!dragPlane.Raycast(touchRay, out enter)) Debug.LogWarning("Bad plane raycast!");

                Vector3 inputPos = touchRay.GetPoint(enter);

                if (pulled) {
                    transform.position = inputPos;
                } else {
                    Vector3 delta = inputPos - transform.position;
                    float deltaZ = Vector3.Dot(transform.forward, delta);
                    transform.position += transform.forward * Mathf.Sign(deltaZ) * pullGive * touch.deltaPosition.magnitude * Time.deltaTime;

                    if ((transform.localPosition - basePosLocal).z < 0f) transform.localPosition = basePosLocal;

                    if ((transform.localPosition - basePosLocal).magnitude > pullDistance) {
                        pulled = true;
                        dragPlane = new Plane(-Camera.main.transform.forward, Camera.main.transform.position + Camera.main.transform.forward * 1f);
                    }
                }

                break;
            case TouchPhase.Ended:
                grabbed = false;
                if (!pulled) transform.localPosition = basePosLocal;
                else destroyTimer = Time.time;
                break;
            default:
                break;
        }
    }

    void AnimationDone() {
        Done();
        Destroy(gameObject);
    }

    void PlaySFX() {
        AudioManager.Instance.Play("Pop");
    }
}