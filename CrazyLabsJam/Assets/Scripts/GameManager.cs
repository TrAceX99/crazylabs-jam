using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}