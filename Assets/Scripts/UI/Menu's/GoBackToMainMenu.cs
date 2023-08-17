using UnityEngine;

public sealed class GoBackToMainMenu : MenuController
{
    [SerializeField] private float duration;

    private void Update()
    {
        duration -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || duration <= 0) GoToMainMenu();
    }
}
