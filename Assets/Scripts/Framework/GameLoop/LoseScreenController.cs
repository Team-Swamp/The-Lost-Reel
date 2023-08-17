using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public sealed class LoseScreenController : MenuController
{
    [SerializeField] private GameObject loseScreen;

    [SerializeField] private UnityEvent OnLosing = new UnityEvent();
    
    public void LosingCondition()
    {
        OnLosing?.Invoke();
        Time.timeScale = 0;
        loseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
