using UnityEngine;

[System.Serializable]
public class MeshSwapSet : CustomizationSet {

    [System.Serializable]
    public class MeshOption : CustomizationOption {
        public Mesh mesh;
    }

    [SerializeField] MeshFilter affectedMesh;
    [SerializeField] MeshOption[] options;
    
    public override void ApplyOption(int optionID) {
        base.ApplyOption(optionID);
        affectedMesh.mesh = options[optionID].mesh;
    }
}