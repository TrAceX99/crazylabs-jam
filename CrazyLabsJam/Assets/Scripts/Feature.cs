using UnityEngine;

public class Feature : MonoBehaviour {
    [SerializeField] LayerMask noSpawnZones;


    // public void RandomizePosition() {
    //     RaycastHit hit;
    //     Vector3 rayOrigin;

    //     do {
    //         rayOrigin = Random.onUnitSphere * 10f;
    //         monster.body.Raycast(new Ray(rayOrigin, monster.body.transform.position - rayOrigin), out hit, 20f);
    //     //     angle = Vector3.Angle(rayOrigin, Vector3.up);
    //     // } while (angle < minFeatureSpawnAngle || angle > maxFeatureSpawnAngle);
    //     } while (Physics.CheckSphere(hit.point, 0.05f, noSpawnZones));

    //     transform.position = hit.point;
    //     transform.rotation = Quaternion.LookRotation(hit.point, transform.up);
    //     Physics.SyncTransforms();
    // }
}