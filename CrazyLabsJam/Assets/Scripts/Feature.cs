using UnityEngine;

public class Feature : MonoBehaviour {
    [SerializeField] LayerMask noSpawnZones;
    [SerializeField] float zoomedInDistance = 2f;

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
        Vector3 rawPos = transform.position + transform.forward * zoomedInDistance;
        cameraController.ZoomIn(rawPos);
        monster.touchRotate.LockRotation(rawPos);
        selected = true;
    }

    public void Deselect() {
        selected = false;
        monster.touchRotate.UnlockRotation();
        cameraController.ZoomOut();
    }

    public void RandomizePosition() {
        RaycastHit hit;
        Vector3 rayOrigin;

        do {
            rayOrigin = Random.onUnitSphere * 10f;
            monster.body.Raycast(new Ray(rayOrigin, monster.body.transform.position - rayOrigin), out hit, 20f);
        //     angle = Vector3.Angle(rayOrigin, Vector3.up);
        // } while (angle < minFeatureSpawnAngle || angle > maxFeatureSpawnAngle);
        } while (Physics.CheckSphere(hit.point, 0.05f, noSpawnZones));

        transform.position = hit.point;
        transform.rotation = Quaternion.LookRotation(hit.point, transform.up);
        Physics.SyncTransforms();
    }
}