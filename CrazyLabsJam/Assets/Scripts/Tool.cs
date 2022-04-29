using UnityEngine;
using UnityEngine.UI;

public class Tool : MonoBehaviour {
    [SerializeField] Sprite[] toolSprites;

    Image image;

    private void Start() {
        image = GetComponent<Image>();
    }

    private void Update() {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        switch (touch.phase) {
            case TouchPhase.Began:
                if (GameManager.Instance.player.selectedTool == ToolType.None) break;
                transform.position = touch.position;
                Invoke("ShowTool", GameManager.Instance.player.selectedTool == ToolType.TapTool ? 0 : 0.15f);
                break;
            case TouchPhase.Moved:
                transform.position = touch.position;
                break;
            case TouchPhase.Ended:
                CancelInvoke();
                image.enabled = false;
                break;
            default:
                break;
        }
    }

    void ShowTool() {
        if (Input.touchCount == 0) return;
        image.enabled = true;
        image.sprite = toolSprites[(int)GameManager.Instance.player.selectedTool];
    }
}