using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class WinScreenController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool _canWin;

    public void SetWinConditionOn() => _canWin = true;

    private void OnTriggerEnter(Collider other)
    {
        if(!_canWin || other.gameObject != player) return;

        Cursor.lockState = CursorLockMode.None;
        GoToWinScreen();
    }

    private void GoToWinScreen() => SceneManager.LoadScene("WinningScene");
}
