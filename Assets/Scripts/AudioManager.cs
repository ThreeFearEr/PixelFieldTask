using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    public static AudioManager Instance;
    private AudioSource audioSource;

    Dictionary<string, AudioClip> soundEffects = new Dictionary<string, AudioClip>();

    void Awake() {
        if(Instance == null) Instance = this;
        audioSource = GetComponent<AudioSource>();

        foreach(AudioClip soundEffect in Resources.LoadAll<AudioClip>("Audio/")) {
            soundEffects.Add(soundEffect.name, soundEffect);
            audioSource.clip = soundEffect;
            audioSource.Play();
            audioSource.Pause();
        }
    }

    public void PlayAudio(string key) {
        if(!soundEffects.ContainsKey(key)) {
            Debug.LogWarning("Source not found [" + key + "]");
            return;
        }

        audioSource.clip = soundEffects[key];
        audioSource.Play();
    }
}
