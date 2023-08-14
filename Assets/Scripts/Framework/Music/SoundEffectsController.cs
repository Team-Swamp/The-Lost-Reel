using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public void PlayRandomGrowl()
    {
        var randomNumber = Random.Range(0, 2) + 2;
        ChangeSoundEffect(randomNumber);
    }
    
    public void PlayBoneCrack(float delayTime) => StartCoroutine(BoneCrack(delayTime));

    private IEnumerator BoneCrack(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ChangeSoundEffect(8);
    }
}
