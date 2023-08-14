using System.Collections;
using UnityEngine;

public class ChasingState : MonsterBaseState
{
    [SerializeField] private float killRange = 0.1f;
    [SerializeField, Range(1, 60)] private float leaveChaseTime = 10;
    [SerializeField, Range(3.5f, 7f)] private float chaseSpeed;
    
    private const float BaseSpeed = 3.5f;
    private bool _isChasing;
    private bool _isLeaveChaseCalled;

    protected override void EnterState(MonsterStateMachine monster)
    {
        _isChasing = true;
        monster.startChasing?.Invoke();
        monster.Agent.speed = chaseSpeed;
    }

    protected override void UpdateState(MonsterStateMachine monster)
    {
        UpdateAnimations(monster, "Chasing", "Chasing-crawl");
        monster.Agent.SetDestination(monster.Player.transform.position);

        if (_isChasing && monster.GetDistanceBetweenPlayer(killRange))
        {
            IsValidToSwitch = true;
            monster.SwitchState(monster.killState);
        }

        StartCoroutine(LeaveChase(monster));
    }
    
    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster)
    {
        monster.Agent.speed = BaseSpeed;
        _isLeaveChaseCalled = false;
    }

    private IEnumerator LeaveChase(MonsterStateMachine monster)
    {
        if(_isLeaveChaseCalled) yield break;
        _isLeaveChaseCalled = true;
        
        yield return new WaitForSeconds(leaveChaseTime);
        monster.Agent.SetDestination(transform.position);
        _isChasing = false;
        IsValidToSwitch = true;
        monster.SwitchState(monster.idleState);

        StartCoroutine(monster.SetPlayerCanBeFound());
    }
}
