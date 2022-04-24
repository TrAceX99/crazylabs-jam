using UnityEngine;

public class TouchRotate : MonoBehaviour {

    [SerializeField] float rotateFactor;
    [SerializeField] float slowdownFactor;
    [SerializeField] float lockedRotateSpeed = 5f;
    [SerializeField] bool mouseInput = false;

    bool touchRotation;
    float velocity;
    float oldMousePosX = 0f;
    Quaternion targetRot;

    private void Start() {
        UnlockRotation();
    }

    private void Update() {
        if (touchRotation) {
            #if UNITY_EDITOR
            if (mouseInput && Input.GetMouseButton(0)) {
                if (Input.GetMouseButtonDown(0)) oldMousePosX = Input.mousePosition.x;
                velocity = rotateFactor * -(Input.mousePosition.x - oldMousePosX);
                oldMousePosX = Input.mousePosition.x;
            }
            #endif

            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        velocity = 0f;
                        break;
                    case TouchPhase.Moved:
                        velocity = rotateFactor * -touch.deltaPosition.x;
                        break;
                    default:
                        break;
                }
            }
            
            transform.Rotate(Vector3.up, velocity * Time.deltaTime);

            velocity = Mathf.SmoothStep(velocity, 0f, Time.deltaTime * slowdownFactor);
        } else {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * lockedRotateSpeed);
        }
    }

    public void LockRotation(Vector3 alignPoint) {
        alignPoint.y = 0f;
        targetRot = transform.rotation * Quaternion.Inverse(Quaternion.LookRotation(alignPoint, Vector3.up));
        touchRotation = false;
    }

    public void UnlockRotation() {
        velocity = 0f;
        targetRot = transform.rotation;
        touchRotation = true;
    }
}