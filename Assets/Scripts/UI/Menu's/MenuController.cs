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
    
    private bool _setPauseMenu;

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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_setPauseMenu)
            {
                ResumeGame();
                activePauseMenu.SetActive(false);
            }
            else
            {
                activePauseMenu.SetActive(true);
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {   
        activePauseScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        _setPauseMenu = true;
    }

    public void ResumeGame()
    {
        activePauseScreen.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        _setPauseMenu = false;
    }

    public void GoToMainMenu() => SceneManager.LoadScene("MainMenu");
    
    public void PlayGame() => SceneManager.LoadScene("MainScene");

    public void CreditScreen() => SceneManager.LoadScene("Credits");

    public void Quitgame() => Application.Quit();
    
}
