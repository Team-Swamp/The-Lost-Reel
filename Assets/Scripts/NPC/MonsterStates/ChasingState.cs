using UnityEngine;

public class ChasingState : MonsterBaseState
{
    protected override void EnterState(MonsterStateMachine monster) { }

    protected override void UpdateState(MonsterStateMachine monster)
    {
        monster.Agent.SetDestination(monster.Player.transform.position);
    }
    
    protected override void FixedUpdateState(MonsterStateMachine monster) { }
    protected override void ExitState(MonsterStateMachine monster) { }
}
