using System.Collections;
using UnityEngine;

public sealed class WinScreenController : MenuController
{
    [SerializeField] private GameObject player;
    [SerializeField] private WarningText flashingText;
    [SerializeField, Range(0, 10)] private float waitForObjectiveTime;

    private bool _canWin;

    private void Start() => StartCoroutine(WaitingTimeForObjectiveScreen(waitForObjectiveTime));

    public void SetWinConditionOn() => _canWin = true;

    private void OnTriggerEnter(Collider other)
    {
        flashingText.SetIsAllowedToFlash(true);
        
        if(!_canWin || other.gameObject != player) return;

        Cursor.lockState = CursorLockMode.None;
        GoToCreditScreen();
    }

    private void OnTriggerExit(Collider other) => flashingText.SetIsAllowedToFlash(false);

    private IEnumerator WaitingTimeForObjectiveScreen(float waitTime)
    {
        waitForObjectiveTime = waitTime;
        yield return new WaitForSeconds(waitTime);
        flashingText.SetIsAllowedToFlash(true);
    }
}
