using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class WinScreenController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool _isPickedUp;

    public void ApplyPickup() => _isPickedUp = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != player) return;
        if(_isPickedUp == false) return;
        
        Cursor.lockState = CursorLockMode.None;
        GoToWinScreen();
    }

    private void GoToWinScreen() => SceneManager.LoadScene("WinningScene");
}
