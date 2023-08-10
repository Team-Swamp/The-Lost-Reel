using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip startMusic;
    [SerializeField] private AudioClip audio;
    [SerializeField] private List<AudioClip> audioclips;
    [SerializeField] private AudioSource audioSource;

    private bool activeMusic;

    private void Start()
    {
        audioSource.clip = startMusic;
        audioSource.Play();
    }
    
    public void ChangeMusicToChase()
    {
        audioSource.Stop();
        audio = audioclips[1];
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void ChangeMusicToAmbience()
    {
        audioSource.Stop();
        audio = audioclips[0];
        audioSource.clip = audio;
        audioSource.Play();
    }
}
