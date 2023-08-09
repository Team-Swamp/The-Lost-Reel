using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Random = UnityEngine.Random;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip startMusic;
    [SerializeField] private AudioClip audio;
    [SerializeField] private List<AudioClip> audioclips = new List<AudioClip>();
    [SerializeField] private AudioSource audioSource;

    private bool activeMusic;

    private void Start()
    {
        var i = Random.Range(0, audioclips.Count);
        audio = audioclips[i];
        audioSource.clip = audio;
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeMusicToChase();
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeMusicToIdle();
        }
    }
    
    public void ChangeMusicToChase()
    {
        audioSource.Stop();
        audio = audioclips[1];
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void ChangeMusicToIdle()
    {
        audioSource.Stop();
        audio = audioclips[0];
        audioSource.clip = audio;
        audioSource.Play();
    }
    
    public void ChangeMusicToRandom()
    {
        
    }
}
