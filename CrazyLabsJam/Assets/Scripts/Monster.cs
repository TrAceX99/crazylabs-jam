using UnityEngine;
using System.Collections.Generic;

public class Monster : MonoBehaviour {
    
    public TouchRotate touchRotate { get; private set; }
    public Collider body { get; private set; }

    [SerializeField] GameObject[] bodyPrefabs;
    
    private void Start() {
        touchRotate = GetComponent<TouchRotate>();
        Generate();
    }

    void Generate() {
        body = Instantiate(bodyPrefabs[Random.Range(0, bodyPrefabs.Length)], transform).GetComponent<Collider>();

    }

    // void AddFeatures() {
    //     int featureCount = Random.Range(1, maxFeatures + 1);
    //     features = new Feature[featureCount];

    //     for (int i = 0; i < featureCount; i++) {
    //         GameObject go = Instantiate(featurePrefabs[Random.Range(0, featurePrefabs.Length)], transform);
    //         Feature feature = go.GetComponent<Feature>();
    //         features[i] = feature;
    //         feature.RandomizePosition();
    //     }

    // }
}