using UnityEngine;

public class Feature : MonoBehaviour {
    [SerializeField] LayerMask noSpawnZones;

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
        cameraController.ZoomIn(transform);
        monster.touchRotate.LockRotation(transform.localPosition);
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
        transform.rotation = Quaternion.LookRotation(hit.normal, transform.up);
        Physics.SyncTransforms();
    }
}