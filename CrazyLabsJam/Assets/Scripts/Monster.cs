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
}