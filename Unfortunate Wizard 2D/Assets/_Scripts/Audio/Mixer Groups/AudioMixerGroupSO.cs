using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioMixerGroupSO", menuName = "Scriptable Object/Audio/Audio Mixer Group")]
public class AudioMixerGroupSO : ScriptableObject
{
    [SerializeField] private AudioMixer mixer;
    public AudioMixerGroup MixerGroup;
    [SerializeField] private string exposedParameterName;
    [Range(0.0001f, 1f), Tooltip("Set default volume slider value")] public float VolumeSliderValue = 0.8f;

    public void InitialiseMixerGroupVolume()
    {
        mixer.SetFloat(exposedParameterName, ToDecibels(VolumeSliderValue));
    }
    public void SetAudioLevel(float value)
    {
        mixer.SetFloat(exposedParameterName, ToDecibels(value));
        VolumeSliderValue = value;
    }
    private static float ToDecibels(float value)
    {
        return Mathf.Log10(value) * 20;
    }
}
