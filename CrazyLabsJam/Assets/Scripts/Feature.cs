using UnityEngine;

public class Feature : MonoBehaviour {
    Monster monster;
    CameraController cameraController;
    bool selected;

    private void Start() {
        monster = GetComponentInParent<Monster>();
        cameraController = Camera.main.GetComponent<CameraController>();
        selected = false;
    }

    public void Select() {
        cameraController.ZoomIn(transform);
        monster.touchRotate.LockRotation(transform.localPosition);
        selected = true;
    }

    public void Deselect() {
        selected = false;
        monster.touchRotate.UnlockRotation();
        cameraController.ZoomOut();
    }
}