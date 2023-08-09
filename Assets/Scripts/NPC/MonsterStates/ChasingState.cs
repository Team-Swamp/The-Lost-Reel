using UnityEngine;

public class ChasingState : MonsterBaseState
{
    protected override void EnterState(MonsterStateMachine monster)
    {
        Debug.Log("Start chasing!");
    }

    protected override void UpdateState(MonsterStateMachine monster) { }
    protected override void FixedUpdateState(MonsterStateMachine monster) { }
    protected override void ExitState(MonsterStateMachine monster) { }
}
