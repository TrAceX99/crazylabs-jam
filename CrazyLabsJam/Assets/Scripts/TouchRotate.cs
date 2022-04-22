using UnityEngine;

public class TouchRotate : MonoBehaviour {
    public bool enableRotation;

    [SerializeField] float rotateFactor;
    [SerializeField] float slowdownFactor;

    float velocity;

    private void Start() {
        velocity = 0f;
    }

    private void Update() {
        if (!enableRotation) return;

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