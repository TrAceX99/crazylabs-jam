using UnityEngine;

public class CustomizableSpawner : MonoBehaviour {
    [Range(0f, 1f)]
    [SerializeField] float spawnChance;

    private void Awake() {
        if (spawnChance == 1f) return;

        if (Random.Range(0f, 1f) > spawnChance) {
            GetComponent<DragFeature>().Done();
            Destroy(gameObject);
        }
    }
}