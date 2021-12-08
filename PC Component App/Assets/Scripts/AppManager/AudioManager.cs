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
    private Sound m;
    private string songName;
    [SerializeField]
    Image musicToggleImg;
    [SerializeField]
    Sprite onTexture, offTexture;

    void Awake() {
        /* Part 1: Prepare all sounds for this scene */

        if (instance == null) 
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            if (s.pitch != 0) {
                s.source.pitch = s.pitch;
            }            
            s.source.loop = s.loop;
        }

        /* Part 2: Prepare music setting for this scene */

        // Make sure PlayerPrefs for music setting exists with acceptable value
        if (!PlayerPrefs.HasKey("MusicOn")) {
            Debug.Log("No MusicOn setting found, creating PlayerPrefs entry with value 1");
            PlayerPrefs.SetInt("MusicOn", 1);
        } else if (PlayerPrefs.GetInt("MusicOn") < 0 || PlayerPrefs.GetInt("MusicOn") > 1) {
            Debug.Log("MusicOn PlayerPrefs value is invalid, resetting to 1");
            PlayerPrefs.SetInt("MusicOn", 1);
        }

        // Get song name for this scene if available
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Main Menu") {
            songName = "MainMenuMusic";
        } else if (scene.name == "Tutorial" || scene.name == "Main Scene") {
            songName = "BuilderMusic";
        } else if (scene.name == "Mini Game") {
            songName = "GameMusic";
        }

        // Set music toggle image and/or play music depending on music settings
        if (PlayerPrefs.GetInt("MusicOn") == 1) {
            // toggle image already defaults to "on", just play
            Play(songName);
        } else {
            musicToggleImg.sprite = offTexture;
            m = Array.Find(sounds, sound => sound.name == songName); // prepare song in case they unmute
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
        if (PlayerPrefs.GetInt("MusicOn") == 1) {
            m.source.Stop();
            PlayerPrefs.SetInt("MusicOn", 0);
            musicToggleImg.sprite = offTexture;
        } else {
            m.source.Play();
            PlayerPrefs.SetInt("MusicOn", 1);
            musicToggleImg.sprite = onTexture;
        }
    }
}
