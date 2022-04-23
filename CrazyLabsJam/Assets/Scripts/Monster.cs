using UnityEngine;
using System.Collections.Generic;

public class Monster : MonoBehaviour {
    
    public TouchRotate touchRotate { get; private set; }

    [SerializeField] GameObject[] bodyPrefabs;
    [SerializeField] GameObject[] featurePrefabs;
    [SerializeField] int maxFeatures = 2;

    GameObject body;
    Feature[] features;

    private void Start() {
        touchRotate = GetComponent<TouchRotate>();
        Generate();
    }

    void Generate() {
        body = Instantiate(bodyPrefabs[Random.Range(0, bodyPrefabs.Length)], transform);

        AddFeatures();
    }

    void AddFeatures() {
        int featureCount = Random.Range(1, maxFeatures + 1);
        features = new Feature[featureCount];

        Collider bodyCol = body.GetComponent<Collider>();
        for (int i = 0; i < featureCount; i++) {
            RaycastHit hit;
            Vector3 rayOrigin = Random.onUnitSphere * 10f;
            bodyCol.Raycast(new Ray(rayOrigin, body.transform.position - rayOrigin), out hit, 20f);

            GameObject go = Instantiate(featurePrefabs[Random.Range(0, featurePrefabs.Length)],
                                        hit.point, Quaternion.LookRotation(hit.normal, transform.up), transform);
            Feature feature = go.GetComponent<Feature>();
            features[i] = feature;
        }

    }
}