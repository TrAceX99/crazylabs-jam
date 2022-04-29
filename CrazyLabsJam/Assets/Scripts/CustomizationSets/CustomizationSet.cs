using UnityEngine;

public class CustomizationSet : MonoBehaviour {

    [System.Serializable]
    public abstract class CustomizationOption {
        // Stuff needed for UI goes here
        public Sprite icon;
    }

    // In case things don't work, override this in child classes
    public CustomizationOption[] Options { get { return options; } }

    public int SelectedID { get; private set; }

    [SerializeField] string setName;
    [SerializeField] CustomizationOption[] options;

    private void Awake() {
        SelectedID = -1;
    }
    
    public virtual void ApplyOption(int optionID) {
        SelectedID = optionID;
    }
}