using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MusicController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField, Range(0, 10)] private float waitForMusicTime;
    
    private AudioClip _audio;
    private int _currentSong = 1;

    private void Start() => StartCoroutine(WaitingTime(waitForMusicTime));

    public void ChangeMusic(int clip)
    {
        if (clip == _currentSong) return;
        
        audioSource.Stop();
        _audio = audioClips[clip];
        _currentSong = clip;
        audioSource.clip = _audio;
        audioSource.Play();
    }
    
    private IEnumerator WaitingTime(float waitTime)
    {
        waitForMusicTime = waitTime;
        yield return new WaitForSeconds(waitTime);
        ChangeMusic(0);
    }
}
