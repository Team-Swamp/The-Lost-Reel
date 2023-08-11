using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class MenuController : MonoBehaviour
{
    [Header("Main menu")]
    [SerializeField] private GameObject activeExplanationMenu;
    [SerializeField] private GameObject activeMainMenu;

    [Header("Pause menu")] 
    [SerializeField] private GameObject activePauseMenu;
    [Space]
    [SerializeField] private GameObject activePauseScreen;
    [SerializeField] private GameObject activeOptionsScreen;
    
    private bool _setPauseMenu = true;

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

    private void Start()
    {
        activePauseScreen.SetActive(false);
    }

    private void Update()
    {
        SetPauseMenu();
    }
    
    private void SetPauseMenu()
    {
        if (!Input.GetKeyDown(KeyCode.Tab)) return;
        
        TogglePauseMenu(!_setPauseMenu);
        activePauseMenu.SetActive(!_setPauseMenu);
        activeOptionsScreen.SetActive(false);
    }

    public void TogglePauseMenu(bool isPaused)
    {
        activePauseScreen.SetActive(!isPaused);
        _setPauseMenu = isPaused;
        
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
    
    public void PlayGame() => SceneManager.LoadScene("MainScene");

    public void CreditScreen() => SceneManager.LoadScene("Credits");

    public void Quitgame() => Application.Quit();
    
}
