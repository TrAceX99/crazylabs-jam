using UnityEngine;
using System.Collections.Generic;

public class AudioManager : Singleton<AudioManager> {

    [SerializeField] AudioSource audioSource;

    Dictionary<string, AudioClip> audioClips;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");
        audioClips = new Dictionary<string, AudioClip>();
        foreach (AudioClip clip in clips) {
            audioClips[clip.name] = clip;
        }
    }

    public void Play(string clipName, float volume = 1.0f) {
        AudioClip clip;
        if (!audioClips.TryGetValue(clipName, out clip)) throw new System.Exception("AudioClip " + clipName + " not found!");
        
        Play(clip, volume);
    }

    public void Play(AudioClip clip, float volume = 1.0f) {
        audioSource.PlayOneShot(clip, volume);
    }
}