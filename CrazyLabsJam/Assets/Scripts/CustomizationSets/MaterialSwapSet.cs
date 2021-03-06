using UnityEngine;

[System.Serializable]
public class MaterialSwapSet : CustomizationSet {

    [System.Serializable]
    public class MaterialOption : CustomizationOption {
        public Material material;
    }

    public override CustomizationOption[] Options { get { return options; } }

    [SerializeField] MeshRenderer affectedMesh;
    [SerializeField] MaterialOption[] options;
    
    public override void ApplyOption(int optionID) {
        base.ApplyOption(optionID);
        affectedMesh.material = options[optionID].material;
    }
}