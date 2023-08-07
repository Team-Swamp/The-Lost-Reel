using UnityEngine;

public class WanderingState : MonsterBaseState
{
    protected override void EnterState(MonsterStateMachine monster)
    {
        Debug.Log("Wandering");
    }

    protected override void UpdateState(MonsterStateMachine monster) { }
    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster) { }
}
