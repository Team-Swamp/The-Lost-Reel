using UnityEngine.UI;
using UnityEngine;

public sealed class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text volumeTextUI;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SaveVolume);
        LoadVolume();
    }

    public void VolumeSliderController(float volume)
    {
        volumeTextUI.text = volume.ToString("100.0");
    }

    private void SaveVolume(float volume)
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadVolume();
    }

    private void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
