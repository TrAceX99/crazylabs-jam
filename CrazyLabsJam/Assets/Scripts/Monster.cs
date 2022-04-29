using UnityEngine;
using System.Collections.Generic;

public class Monster : MonoBehaviour {
    
    public TouchRotate touchRotate { get; private set; }
    public AnimationController animationController { get; private set; }

    [SerializeField] GameObject[] bodyPrefabs;

    private void Start() {
        touchRotate = GetComponent<TouchRotate>();
        Generate();
        animationController = GetComponentInChildren<AnimationController>();
    }

    void Generate() {
        Instantiate(bodyPrefabs[Random.Range(0, bodyPrefabs.Length)], transform).GetComponent<Collider>();
    }

    public void Done() {
        touchRotate.LockRotation(touchRotate.transform.forward);
        animationController.PlayExit();
    }
}