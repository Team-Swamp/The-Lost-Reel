using UnityEngine.SceneManagement;
using UnityEngine;

public sealed class MainMenuController : MenuController
{
    [SerializeField] private string mainScene;
    [SerializeField] private GameObject activeExplanationMenu;
    [SerializeField] private GameObject activeMainMenu;
    
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(mainScene);
    }

    public void ToggleToMainMenuFromExplanation(bool goingToExplanation)
    {
        activeMainMenu.SetActive(!goingToExplanation);
        activeExplanationMenu.SetActive(goingToExplanation);
    }
}
