using UnityEngine;

public class AudioManager : Singleton<AudioManager> {

    [SerializeField] AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

}