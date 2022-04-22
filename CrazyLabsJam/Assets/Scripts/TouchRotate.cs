using UnityEngine;

public class TouchRotate : MonoBehaviour {
    public bool enableRotation;

    [SerializeField] float rotateFactor;
    [SerializeField] float slowdownFactor;
    [SerializeField] bool mouseInput = false;

    float velocity;
    float oldMousePosX = 0f;

    private void Start() {
        velocity = 0f;
    }

    private void Update() {
        if (!enableRotation) return;

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
    }
}