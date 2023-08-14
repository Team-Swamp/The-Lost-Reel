using System.Collections;
using UnityEngine;

public class SeekingState : MonsterBaseState
{
    [SerializeField, Range(0.1f, 5f)] private float getPlayerPositionTime = 1;
    [SerializeField, Range(1, 30)] private float waitForPlayerMovingTime = 5;

    private Vector3 _playerPosition;
    private bool _hasPlayerPosition;
    private bool _playerHasWaited;
    private bool _playerHasWaitedIsCalled;

    protected override void EnterState(MonsterStateMachine monster)
    {
        monster.Agent.SetDestination(transform.position);
        UpdateAnimations(monster, "Idle", "Idle-crawl");
        monster.onPlayerFound?.Invoke();
        StartCoroutine(GetPlayerPosition(monster));
    }

    protected override void UpdateState(MonsterStateMachine monster)
    {
        if (!_hasPlayerPosition) return;

        if (!_playerHasWaitedIsCalled) StartCoroutine(SetPlayerHasWaited(monster));
        
        if (_playerPosition != monster.Player.transform.position)
        {
            IsValidToSwitch = true;
            monster.SwitchState(monster.chasingState);
        }
        else if (_playerHasWaited)
        {
            IsValidToSwitch = true;
            monster.onSwitchToWalkingState?.Invoke();
            monster.SwitchState(monster.wanderingState);
        }
    }

    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster)
    {
        _hasPlayerPosition = false;
        _playerHasWaited = false;
        _playerHasWaitedIsCalled = false;
    }

    private IEnumerator GetPlayerPosition(MonsterStateMachine monster)
    {
        yield return new WaitForSeconds(getPlayerPositionTime);
        _hasPlayerPosition = true;
        _playerPosition = monster.Player.transform.position;
        monster.Agent.SetDestination(transform.position);
    }

    private IEnumerator SetPlayerHasWaited(MonsterStateMachine monster)
    {
        _playerHasWaitedIsCalled = true;
        yield return new WaitForSeconds(waitForPlayerMovingTime);
        _playerHasWaited = true;
        StartCoroutine(monster.SetPlayerCanBeFound());
    }
}
