using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip startMusic;
    [SerializeField] private AudioClip audio;
    [SerializeField] private List<AudioClip> audioclips = new List<AudioClip>();
    [SerializeField] private AudioSource audioSource;

    private bool activeMusic;
    
    private void Awake()
    {
        activeMusic = true;
        if(activeMusic = true) AudioSource.PlayClipAtPoint(startMusic, transform.position);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (activeMusic == false)
        {
            audioSource.mute = !audioSource.mute;
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            activeMusic = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            activeMusic = true;
        }
    }
    
    public void ChangeMusicToChase()
    {
 
    }

    public void ChangeMusicToIdle()
    {
        
    }
    
    public void ChangeMusicToRandom()
    {
        
    }
}
