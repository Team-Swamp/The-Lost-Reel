using UnityEngine;
using UnityEngine.UI;

public class OptionsSettings : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private Text sensitivityValueText;
    [SerializeField] private float sensitivity = 2.0f;

    private void Start()
    {
        sensitivitySlider.value = sensitivity;
        UpdateSensitivityValueText();

        sensitivitySlider.onValueChanged.AddListener(ChangeSensitivity);
    }

    private void ChangeSensitivity(float newSensitivity)
    {
        sensitivity = newSensitivity;
        UpdateSensitivityValueText();
    }

    private void UpdateSensitivityValueText()
    {
        sensitivityValueText.text = sensitivity.ToString("F2");
    }

}
