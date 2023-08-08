using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class BackToMainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("MainMenu");
    }
}
