using System.Collections.Generic;
using UnityEngine;

public sealed class SoundEffectsController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> soundEffectClips;
    [SerializeField] private AudioSource audioSource;

    private AudioClip _audio;

    public void ChangeSoundEffect(int clip)
    {
        audioSource.Stop();
        _audio = soundEffectClips[clip];
        audioSource.clip = _audio;
        audioSource.Play();
    }

}
