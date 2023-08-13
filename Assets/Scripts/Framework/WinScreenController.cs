using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class WinScreenController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject objective;
    
    [SerializeField, Range(0, 10)] private float waitForObjectiveTime;

    private bool _canWin;
    private bool _objectiveScreenActive;

    public void SetWinConditionOn() => _canWin = true;

    private void Start()
    {
        _objectiveScreenActive = false;
        StartCoroutine(WaitingTimeForObjectiveScreen(waitForObjectiveTime));
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (!_canWin) _objectiveScreenActive = true;
        if(!_canWin && _objectiveScreenActive) objective.SetActive(true);
        if(_canWin) objective.SetActive(false);
        
        if(!_canWin || other.gameObject != player) return;

        Cursor.lockState = CursorLockMode.None;
        GoToWinScreen();
    }

    private void OnTriggerExit(Collider other)
    {
        _objectiveScreenActive = false;
        if (!_canWin || !_objectiveScreenActive) objective.SetActive(false);
    }

    private IEnumerator WaitingTimeForObjectiveScreen(float waitTime)
    {
        waitForObjectiveTime = waitTime;
        yield return new WaitForSeconds(waitTime);
        if(_objectiveScreenActive) objective.SetActive(true);
    }
    

    private void GoToWinScreen() => SceneManager.LoadScene("Credits");
}
