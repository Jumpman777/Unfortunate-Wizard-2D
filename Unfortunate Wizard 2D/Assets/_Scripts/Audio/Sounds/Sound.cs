using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Sound
{
    public SoundNames Name;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume = 1;

    [Range(0.3f, 3f)]
    public float Pitch = 1;

    public bool Loop = false;

    [Range(0f, 1f)]
    public float SpatialBlend = 0.8f;

    [FormerlySerializedAs("SoundType")] public MixerGroups mixerGroup;

    [HideInInspector] public AudioSource audioSource;
}
