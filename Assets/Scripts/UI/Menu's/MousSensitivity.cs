using UnityEngine;
using UnityEngine.UI;

public sealed class MousSensitivity : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private Text sensitivityValueText;
    [SerializeField] private float sensitivity;
    [SerializeField] private CameraController cameraController;


    private void Start()
    {
        sensitivitySlider.value = sensitivity;

        sensitivitySlider.onValueChanged.AddListener(ChangeSensitivity);
    }

    private void ChangeSensitivity(float newSensitivity) => cameraController.mouseSensitivity = newSensitivity;
}
