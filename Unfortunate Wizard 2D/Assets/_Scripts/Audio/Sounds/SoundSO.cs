using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Scriptable object that stores information for 1 sound and has methods for playing the sound.
/// Set 3D audio settings in the AudioSource component.
/// </summary>
[CreateAssetMenu(fileName = "SoundSO", menuName = "Scriptable Object/Audio/Sound")]
public class SoundSO : ScriptableObject
{
    public SoundNames SoundName;
    
    [SerializeField, NotNull] private AudioClip clip;

    [SerializeField, Range(0f, 1f)]
    private float volume = 1;

    [SerializeField, Range(0.3f, 3f)]
    private float pitch = 1;

    [SerializeField] private bool loop = false;

    [SerializeField, Tooltip("Amount of time needed to pass to play the sound again. Measured in seconds. 0 = no delay limit")] 
    private float playAgainDelay = 0;
    private float nextPlayTime = 0;
    
    [Tooltip("Which mixer group to attach this sound to: Sfx or Music"), NotNull]
    [SerializeField] private AudioMixerGroupSO mixerGroupSO;
    
    [SerializeField, Range(0f, 1f), Tooltip("0 = 2D | 1 = 3D")]
    private float spatialBlend = 0;
    
    /// <summary>
    /// Call ConfigureSource() before playing any sound.
    /// public so that the AudioSource can be changed externally.
    /// </summary>
    public AudioSource AudioSource { get; set; }

    /// <summary>
    /// Usually for playing music.
    /// </summary>
    public void PlaySound()
    {
        if(AudioSource == null) return;
        if (CanPlaySound() == false) return;
        
        AudioSource.Play();
    }

    public void PlaySFX()
    {
        if(AudioSource == null) return;
        if (CanPlaySound() == false) return;
        
        AudioSource.PlayOneShot(clip, volume);
    }
    
    /// <summary>
    /// Use this method for AudioSources that aren't on the object's position. The audio won't move with the object.
    /// </summary>
    /// <param name="position"></param>
    public void PlaySFX3D(Vector3 position)
    {
        if(AudioSource == null) return;
        if (CanPlaySound() == false) return;
        AudioSource.transform.position = position;
        AudioSource.PlayOneShot(clip, volume);
    }
    
    /// <summary>
    /// Configure the AudioSource before playing sounds.
    /// </summary>
    public void ConfigureSource(AudioSource source)
    {
        AudioSource = source;
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
        source.spatialBlend = spatialBlend;
        source.outputAudioMixerGroup = mixerGroupSO.MixerGroup;
    }
    
    /// <summary>
    /// Configure the AudioSource before playing sounds.
    /// </summary>
    /// <param name="gameObject">GameObject to create a new AudioSource on</param>
    public void ConfigureSource(GameObject gameObject)
    {
        ConfigureSource(gameObject.AddComponent<AudioSource>());
    }

    /// <summary>
    /// To determine if enough time has passed for the sound to play again.
    /// </summary>
    /// <returns>response for if the sound is allowed to play</returns>
    private bool CanPlaySound()
    {
        if (playAgainDelay == 0) return true;
        
        if (CheckIfEnoughTimePassed())
        {
            SetNextPlayTime();
            return true;
        }
        return false;
    }
    
    private bool CheckIfEnoughTimePassed()
    {
        return Time.time >= playAgainDelay;
    }
    private void SetNextPlayTime()
    {
        nextPlayTime = Time.time + 1 / playAgainDelay;
    }

    public bool IsSoundPlaying()
    {
        return AudioSource.isPlaying;
    }

    public void StopSound()
    {
        AudioSource.Stop();
    }

    public void PauseSound()
    {
        AudioSource.Pause();
    }
}
