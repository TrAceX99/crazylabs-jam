using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float zoomedInDistance = 1f;

    Vector3 basePos;
    Quaternion baseRot;
    Vector3 targetPos;
    Quaternion targetRot;

    private void Start() {
        basePos = transform.position;
        baseRot = transform.rotation;
        ZoomOut();
    }

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * moveSpeed);
    }

    public void ZoomOut() {
        targetPos = basePos;
        targetRot = baseRot;
    }

    public void ZoomIn(Transform target) {
        Vector3 rawPos = target.position + target.forward * zoomedInDistance;
        Vector3 newPos = new Vector3(0f, rawPos.y, 0f);
        rawPos.y = 0f;
        newPos.z = -rawPos.magnitude;
        targetPos = newPos;

        targetRot = Quaternion.LookRotation(-newPos, Vector3.up);
    }
}