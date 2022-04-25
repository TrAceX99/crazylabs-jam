using UnityEngine;

public class Customizable : MonoBehaviour {
    [SerializeField] Transform cameraPos;

    Monster monster;
    CameraController cameraController;
    Collider coll;
    bool selected;

    private void Awake() {
        monster = GetComponentInParent<Monster>();
        cameraController = Camera.main.GetComponent<CameraController>();
        coll = GetComponent<Collider>();
        selected = false;
    }

    public void Select() {
        cameraController.ZoomIn(cameraPos);
        monster.touchRotate.LockRotation(cameraPos.position);
        selected = true;
    }

    public void Deselect() {
        selected = false;
        monster.touchRotate.UnlockRotation();
        cameraController.ZoomOut();
    }
}