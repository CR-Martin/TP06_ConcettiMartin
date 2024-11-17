using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private Clip[] musicSounds, effectSounds, uiSounds;
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioSource musicSource, effectSource, uiSource;

    private string lastSong;
    private float musicVolume;
    private float EffectVolume;
    private float UiVolume;

    private const string MixerMusic = "MusicVolume";
    private const string MixerEffect = "EffectVolume";
    private const string MixerUI= "UiVolume";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(string musicName)
    {
        Clip sound = Array.Find(musicSounds, x => x.soundName == musicName);
        if (sound == null)
        {
            Debug.LogError("Sound not found");
        }
        else
        {
            if (musicName == lastSong) return;
            lastSong = sound.soundName;
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlayEffect(string effectName)
    {
        Clip effect = Array.Find(effectSounds, x => x.soundName == effectName);
        if (effect == null)
        {
            Debug.LogError("Effect not found");
        }
        else
        {
            effectSource.PlayOneShot(effect.clip);
        }
    }

    public void PlayUI(string uiName) 
    {
        Clip effect = Array.Find(uiSounds, x => x.soundName == uiName);
        if (effect == null)
        {
            Debug.LogError("Effect not found");
        }
        else
        {
            uiSource.PlayOneShot(effect.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        musicVolume = volume;
        audioMixer.SetFloat(MixerMusic, Mathf.Log10(volume) * 20);
    }
    public void SfxVolume(float volume)
    {
        EffectVolume = volume;
        audioMixer.SetFloat(MixerEffect, Mathf.Log10(volume) * 20);
    }

    public void UIVolume(float volume)
    {
        UiVolume = volume;
        audioMixer.SetFloat(MixerUI, Mathf.Log10(volume) * 20);
    }
}
