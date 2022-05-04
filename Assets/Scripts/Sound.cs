using UnityEngine.Audio;
using UnityEngine;
using System;


[System.Serializable]
public class Sound {

    public AudioClip clip;

    public string name;
    
    [Range(0f,1f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;

    //[HideInInspector] //even though public won't show, security reasons
    public AudioSource source;

}