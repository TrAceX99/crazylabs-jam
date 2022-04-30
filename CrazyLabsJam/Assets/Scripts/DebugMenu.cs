using UnityEngine;

public class DebugMenu : Singleton<DebugMenu> {
    public float cameraDistance = 0f;
    public float cameraSpeed = 0f;
    public float volume = 1f;

    

    public void SpawnNewMonster(int id) {
        GameManager.Instance.RemoveMonster();
        GameManager.Instance.NewMonster(id);
    }
}