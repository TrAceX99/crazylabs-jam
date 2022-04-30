using UnityEngine;
using System.Collections.Generic;

public class Monster : MonoBehaviour {
    public int spawnID = -1;
    
    public TouchRotate touchRotate { get; private set; }
    public AnimationController animationController { get; private set; }

    [SerializeField] GameObject[] bodyPrefabs;

    private void Start() {
        touchRotate = GetComponent<TouchRotate>();
        Generate();
        animationController = GetComponentInChildren<AnimationController>();
    }

    void Generate() {
        int index = Random.Range(0, bodyPrefabs.Length);
        if (spawnID >= 0) index = spawnID; 
        Instantiate(bodyPrefabs[index], transform).GetComponent<Collider>();
        if (index == 2) UIManager.Instance.ShowNextMonsterButton();
    }

    public void Done() {
        touchRotate.LockRotation(touchRotate.transform.forward);
        animationController.PlayExit();
    }

    public void HappyFace() {
        FaceRandomizer[] features = GetComponentsInChildren<FaceRandomizer>();
        foreach (FaceRandomizer randomizer in features) {
            randomizer.RanodmizeHappy();
        }
    }
}