using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField, Tooltip("Slider UnityEvent is subscribed to in this class")] private Slider slider;
    [SerializeField] private AudioMixerGroupSO audioMixerGroup;

    private void Awake()
    {
        audioMixerGroup.InitialiseMixerGroupVolume(); // an AudioManager can also initialize the the volume. I do it here in case there is no AudioManager
    }

    private void OnEnable()
    {
        slider.value = audioMixerGroup.VolumeSliderValue;
        slider.onValueChanged.AddListener(SetAudioLevel);
    }
    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }

    private void SetAudioLevel(float value)
    {
        audioMixerGroup.SetAudioLevel(value);
    }
}
