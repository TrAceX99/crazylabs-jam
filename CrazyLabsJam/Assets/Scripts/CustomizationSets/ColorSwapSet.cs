using UnityEngine;

[System.Serializable]
public class ColorSwapSet : CustomizationSet {

    [System.Serializable]
    public class ColorOption : CustomizationOption {
        public Color color;
    }

    public override CustomizationOption[] Options { get { return options; } }

    [SerializeField] Material affectedMaterial;
    [SerializeField] ColorOption[] options;
    
    public override void ApplyOption(int optionID) {
        base.ApplyOption(optionID);
        affectedMaterial.color = options[optionID].color;
    }
}