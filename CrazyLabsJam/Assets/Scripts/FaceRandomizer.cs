using UnityEngine;

public class FaceRandomizer : MonoBehaviour {
    [SerializeField] Material[] sadFaces;
    [SerializeField] Material[] happyFaces;

    MeshRenderer meshRenderer;

    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
        Ranodmize(sadFaces);
    }

    void Ranodmize(Material[] choices) {
        meshRenderer.material = choices[Random.Range(0, choices.Length)];
    }

    public void RanodmizeHappy() {
        Ranodmize(happyFaces);
    }
}