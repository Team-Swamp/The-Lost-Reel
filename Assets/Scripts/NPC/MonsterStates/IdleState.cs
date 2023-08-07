using UnityEngine;

public class IdleState : MonsterBaseState
{
    [SerializeField, Range(0, 15)] private float waitTime;
    [SerializeField] private Animator animator;

    private float _currentWaitTime;

    protected override void EnterState(MonsterStateMachine monster)
    {
        Debug.Log("Idle");
        IsValidToSwitch = true;
        
        //todo: Play idle animation
        
        _currentWaitTime = waitTime;
    }

    protected override void UpdateState(MonsterStateMachine monster) { }

    protected override void FixedUpdateState(MonsterStateMachine monster)
    {
        _currentWaitTime -= Time.deltaTime;
        
        if (_currentWaitTime <= 0) monster.SwitchState(monster.wanderingState);
    }

    protected override void ExitState(MonsterStateMachine monster) { }
}
