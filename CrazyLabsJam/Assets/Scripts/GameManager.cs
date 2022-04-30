using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {
    public Player player { get; private set; }
    public Monster monster { get; private set; }

    [SerializeField] GameObject monsterPrefab;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        NewMonster();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.Space)) Done();
    }

    public void NewMonster(int id = -1) {
        player.inputEnabled = false;
        monster = Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity).GetComponent<Monster>();
        monster.spawnID = id;
    }

    public void RemoveMonster() {
        Destroy(monster.gameObject);
    }

    public void Done() {
        monster.Done();
        player.inputEnabled = false;
    }
}