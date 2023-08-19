using UnityEngine.SceneManagement;
using UnityEngine;

public sealed class MainMenuController : MenuController
{
    [SerializeField] private string mainScene;
    [SerializeField] private GameObject explanationMenu;
    [SerializeField] private GameObject mainMenu;

    public void PlayGame() => SceneManager.LoadSceneAsync(mainScene);

    public void ToggleToMainMenuFromExplanation(bool goingToExplanation)
    {
        mainMenu.SetActive(!goingToExplanation);
        explanationMenu.SetActive(goingToExplanation);
    }
}
