using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseScreenController : MenuController
{
    [SerializeField] private GameObject activateLoseScreen;
    
    public void LosingCondition()
    {
        _hasLost = true;
        Time.timeScale = 0;
        activateLoseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    } 
}
