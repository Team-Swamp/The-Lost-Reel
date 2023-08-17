using UnityEngine;

public class PauseController : MenuController
{
    [SerializeField] private GameObject activePauseMenu;
    [SerializeField] private GameObject activePauseScreen;
    [SerializeField] private GameObject activeOptionsScreen;
    
    private bool _isNotPaused = true;

    private void Start() 
    {
        if (activePauseScreen) activePauseScreen.SetActive(false);
    }

    private void Update() => UpdatePauseMenu();
    
    public void ToggleToPauseScreenFromOptions(bool goingToOptions)
    {
        activePauseScreen.SetActive(!goingToOptions);
        activeOptionsScreen.SetActive(goingToOptions);
    }

    private void UpdatePauseMenu()
    {
        if (_hasLost || !Input.GetKeyDown(KeyCode.Tab)) return;
        
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
}
