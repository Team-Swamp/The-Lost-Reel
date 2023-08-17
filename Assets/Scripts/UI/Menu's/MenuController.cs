using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenuController : MonoBehaviour
{
    protected bool _hasLost;
    
    public void GoToMainMenu() => SceneManager.LoadScene("MainMenu");
    
    public void GoToCreditScreen() => SceneManager.LoadScene("Credits");

    public void QuitGame() => Application.Quit();
}
