using UnityEngine;

public sealed class PauseController : MenuController
{
    [SerializeField] private GameObject parentPauseMenu;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject optionsScreen;

    private bool _canPause = true;
    private bool _isPaused;

    private void Start() 
    {
        if (pauseScreen) pauseScreen.SetActive(false);
    }

    private void Update() => UpdatePauseMenu();
    
    public void ToggleToPauseScreenFromOptions(bool isGoingToOptions)
    {
        pauseScreen.SetActive(!isGoingToOptions);
        optionsScreen.SetActive(isGoingToOptions);
    }

    private void UpdatePauseMenu()
    {
        if (!_canPause || !Input.GetKeyDown(KeyCode.Tab)) return;
        
        TogglePauseMenu(_isPaused);
        parentPauseMenu.SetActive(_isPaused);
        optionsScreen.SetActive(false);
    }

    public void SetLoseConditionActive() => _canPause = false;

    public void TogglePauseMenu(bool isPaused)
    {
        pauseScreen.SetActive(!isPaused);
        _isPaused = !isPaused;

        Time.timeScale = isPaused ? 1 : 0;
        Cursor.lockState = isPaused ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
