using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SeekingState : MonsterBaseState
{
    [SerializeField, Range(0.1f, 5f)] private float getPlayerPositionTime = 1;
    [SerializeField, Range(1, 30)] private float waitForPlayerMovingTime = 1;
    [Space, Space]
    [SerializeField] private UnityEvent onPlayerFound = new UnityEvent();
    [SerializeField] private UnityEvent onSwitchToWalkingState = new UnityEvent();
    
    private Vector3 _playerPosition;
    private bool _hasPlayerPosition;
    private bool _playerHasWaited;

    protected override void EnterState(MonsterStateMachine monster)
    {
        onPlayerFound?.Invoke();
        StartCoroutine(GetPlayerPosition(monster));
    }

    protected override void UpdateState(MonsterStateMachine monster)
    {
        if (!_hasPlayerPosition) return;

        StartCoroutine(SetPlayerHasWaited());
        
        if (_playerPosition != monster.Player.transform.position)
        {
            IsValidToSwitch = true;
            monster.SwitchState(monster.chasingState);
        }
        else if (_playerHasWaited)
        {
            IsValidToSwitch = true;
            onSwitchToWalkingState?.Invoke();
            monster.SwitchState(monster.wanderingState);
        }
    }

    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster)
    {
        _hasPlayerPosition = false;
        _playerHasWaited = false;
    }

    private IEnumerator GetPlayerPosition(MonsterStateMachine monster)
    {
        yield return new WaitForSeconds(getPlayerPositionTime);
        _hasPlayerPosition = true;
        _playerPosition = monster.Player.transform.position;
        monster.Agent.SetDestination(transform.position);
    }

    private IEnumerator SetPlayerHasWaited()
    {
        if(_playerHasWaited) yield break;

        yield return new WaitForSeconds(waitForPlayerMovingTime);
        _playerHasWaited = true;
    }
}
