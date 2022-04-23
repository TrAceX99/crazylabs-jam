using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {
    public Player player { get; private set; }
    // public Monster monster { get; private set; }

    [SerializeField] GameObject monsterPrefab;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // monster = Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity).GetComponent<Monster>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}