using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ChasingState : MonsterBaseState
{
    [SerializeField] private float killRange = 0.1f;
    [SerializeField, Range(1, 60)] private float leaveChaseTime = 10;

    [SerializeField] private UnityEvent startChasing = new UnityEvent();
    
    private bool _isChasing;
    private bool _isLeaveChaseCalled;

    protected override void EnterState(MonsterStateMachine monster)
    {
        Debug.Log("Chase");
        _isChasing = true;
        startChasing?.Invoke();
    }

    protected override void UpdateState(MonsterStateMachine monster)
    {
        monster.Agent.SetDestination(monster.Player.transform.position);

        if (_isChasing && monster.GetDistanceBetweenPlayer(killRange))
        {
            IsValidToSwitch = true;
            monster.SwitchState(monster.killState);
        }
        else if(!_isChasing)
        {
            IsValidToSwitch = true;
            monster.SwitchState(monster.idleState);
        }

        StartCoroutine(LeaveChase());
    }
    
    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster)
    {
        _isChasing = false;
        _isLeaveChaseCalled = false;
    }

    private IEnumerator LeaveChase()
    {
        if(_isLeaveChaseCalled) yield break;
        _isLeaveChaseCalled = true;
        
        yield return new WaitForSeconds(leaveChaseTime);
        _isChasing = false;
    }
}
