using UnityEngine;

public class DebugMenu : Singleton<DebugMenu> {
    public float cameraDistance = 0f; // -5f to 5f
    public float cameraSpeed = 1f; // 0.5f to 2f 
    public float volume = 1f; // 0f to 1f
    public float pullGiveMultiplier = 1f; // 0.5f to 2f

    // Three buttons, id = 0, 1, 2
    public void SpawnNewMonster(int id) {
        GameManager.Instance.RemoveMonster();
        GameManager.Instance.NewMonster(id);
    }
}