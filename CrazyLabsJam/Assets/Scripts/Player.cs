using UnityEngine;

public class Player : MonoBehaviour {

    private void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                default:
                    break;
            }
        }
    }
}