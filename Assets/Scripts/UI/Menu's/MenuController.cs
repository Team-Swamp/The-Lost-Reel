using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenuController : MonoBehaviour
{
    public void GoToMainMenu()
    {
        TimeScaleController.SetTimeScale(1);
        SceneManager.LoadScene("MainMenu");
    } 
    
    public void GoToCreditScreen() => SceneManager.LoadScene("Credits");

    public void QuitGame() => Application.Quit();
}
