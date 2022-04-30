using UnityEngine;

public class DebugMenu : Singleton<DebugMenu>
{
    public float _cameraDistance = 0f; // -5f to 5f
    public float cameraDistance
    {
        get
        {
            return _cameraDistance;
        }
        set
        {
            _cameraDistance = value;
        }
    }
    public float _cameraSpeed = 1f; // 0.5f to 2f 
    public float cameraSpeed {
        get
        {
            return _cameraSpeed;
        }
        set
        {
            _cameraSpeed = value;
        }
    }
    public float _volume = 1f; // 0f to 1f
    public float volume {
        get
        {
            return _volume;
        }
        set
        {
            _volume = value;
        }
    }
    public float _pullGiveMultiplier = 1f; // 0.5f to 2f
    public float pullGiveMultiplier {
        get
        {
            return _pullGiveMultiplier;
        }
        set
        {
            _pullGiveMultiplier = value;
        }
    }


    public void Start(){
        this.Hide();
    }



    // Three buttons, id = 0, 1, 2
    public void SpawnNewMonster(int id)
    {
        GameManager.Instance.RemoveMonster();
        GameManager.Instance.NewMonster(id);
    }



    public void SpawnGhost(){
        Debug.Log("Spawning with ID: 0" );
        SpawnNewMonster(0);
    }

    public void SpawnAlien(){
        Debug.Log("Spawning with ID: 1" );
        SpawnNewMonster(1);

    }

    public void SpawnDemon(){
        Debug.Log("Spawning with ID: 2" );
        SpawnNewMonster(2);
    }


    public void Show(){
        this.gameObject.SetActive(true);
    }

    public void Hide(){
        this.gameObject.SetActive(false);
    }
}