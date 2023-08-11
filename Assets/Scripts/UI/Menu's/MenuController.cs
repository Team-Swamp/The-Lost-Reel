using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class MenuController : MonoBehaviour
{
    [SerializeField] private string mainScene;
    [SerializeField] private GameObject activeExplanationMenu;
    [SerializeField] private GameObject activeMainMenu;

    public void ToggleToMainMenuFromExplanation(bool goingToExplanation)
    {
        activeMainMenu.SetActive(!goingToExplanation);
        activeExplanationMenu.SetActive(goingToExplanation);
    }
    
    public void PlayGame() => SceneManager.LoadScene(mainScene);
    
    public void CreditScreen() => SceneManager.LoadScene("Credits");

    public void Quitgame() => Application.Quit();
}
