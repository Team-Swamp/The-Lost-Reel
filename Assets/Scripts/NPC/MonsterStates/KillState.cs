using UnityEngine;

public class KillState : MonsterBaseState
{
    protected override void EnterState(MonsterStateMachine monster)
    {
        Debug.Log("Make the jumpScare");
    }

    protected override void UpdateState(MonsterStateMachine monster) { }

    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster) { }
}
