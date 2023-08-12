using System.Collections.Generic;
using UnityEngine;

public sealed class MusicController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioclips;
    [SerializeField] private AudioSource audioSource;
    
    private AudioClip _audio;

    private void Start() => ChangeMusic(0);

    public void ChangeMusic(int clip)
    {
        audioSource.Stop();
        _audio = audioclips[clip];
        audioSource.clip = _audio;
        audioSource.Play();
    }
}
