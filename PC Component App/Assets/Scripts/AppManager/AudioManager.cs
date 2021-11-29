using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    public static AudioManager instance;
    // music-specific vars
    public bool musicOn; // redundant, but keeping in case we implement long-term saving of muting decisions thru player data
    private Sound m;
    private string songName;
    [SerializeField]
    Image musicToggleImg;
    [SerializeField]
    Sprite onTexture, offTexture;

    void Awake() {
        if (instance == null) 
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
        musicOn = true;
        
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            if (s.pitch != 0) {
                s.source.pitch = s.pitch;
            }            
            s.source.loop = s.loop;
        }

        // Prepare/play appropriate music for scene
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Main Menu") {
            songName = "MainMenuMusic";
            Play(songName);
        } else if (scene.name == "Tutorial" || scene.name == "Main Scene") {
            songName = "BuilderMusic";
            Play(songName);
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)  { // if sound doesn't exist
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        } else if (name == songName) { // if sound is music
            m = s;
            m.source.Play();
        } else { // if sound is sfx
            s.source.Play();
        }
    }

    public void ToggleMusic() {
        if (musicOn) {
            m.source.Stop();
            musicOn = false;
            musicToggleImg.sprite = offTexture;
        } else {
            m.source.Play();
            musicOn = true;
            musicToggleImg.sprite = onTexture;
        }
    }
}
