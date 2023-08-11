using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class MenuController : MonoBehaviour
{
    [Header("Main menu")]
    [SerializeField] private string mainScene;
    [SerializeField] private GameObject activeExplanationMenu;
    [SerializeField] private GameObject activeMainMenu;

    [Header("Pause menu")] 
    [SerializeField] private GameObject activePauseMenu;
    [Space]
    [SerializeField] private GameObject activePauseScreen;
    [SerializeField] private GameObject activeOptionsScreen;
    
    private bool _isNotPaused = true;

    public void ToggleToMainMenuFromExplanation(bool goingToExplanation)
    {
        activeMainMenu.SetActive(!goingToExplanation);
        activeExplanationMenu.SetActive(goingToExplanation);
    }

    public void ToggleToPauseScreenFromOptions(bool goingToOptions)
    {
        activePauseScreen.SetActive(!goingToOptions);
        activeOptionsScreen.SetActive(goingToOptions);
    }

    private void Start() => activePauseScreen.SetActive(false);

    private void Update() => UpdatePauseMenu();

    private void UpdatePauseMenu()
    {
        if (!Input.GetKeyDown(KeyCode.Tab)) return;
        
        TogglePauseMenu(!_isNotPaused);
        activePauseMenu.SetActive(!_isNotPaused);
        activeOptionsScreen.SetActive(false);
    }

    public void TogglePauseMenu(bool isPaused)
    {
        activePauseScreen.SetActive(!isPaused);
        _isNotPaused = isPaused;
        
        if (isPaused)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GoToMainMenu() => SceneManager.LoadScene("MainMenu");
    
    public void PlayGame() => SceneManager.LoadScene(mainScene);
    
    public void CreditScreen() => SceneManager.LoadScene("Credits");

    public void Quitgame() => Application.Quit();
}
