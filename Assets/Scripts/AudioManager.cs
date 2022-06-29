using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    public AudioSource currentSound; 

    void Awake()
    {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            currentSound = s.source;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void Update() {
        IsPlaying();
    }

    public void Play(string name) {
       Sound s =  Array.Find(sounds, sound => sound.name == name);
       if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
       } else if (s.source != null) {
            s.source.Play();
       }
    }
    public void Stop(string name) {
       Sound s =  Array.Find(sounds, sound => sound.name == name);
       if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
       } else if (s.source != null) {
            s.source.Stop();
       }
    }

    public bool IsPlaying() {
        return currentSound.isPlaying;
    }
}
