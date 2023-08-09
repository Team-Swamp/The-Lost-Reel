using UnityEngine;

public class ChasingState : MonsterBaseState
{
    protected override void EnterState(MonsterStateMachine monster) { }

    protected override void UpdateState(MonsterStateMachine monster)
    {
        // monster.Agent.SetDestination(monster.Player.transform.position);
        // monster.Agent.Move(monster.Player.transform.position);
        // monster.Agent.Warp(monster.Player.transform.position);
        // monster.Agent.destination = monster.Player.transform.position;

        // This al give a error ^^
        // trying to update the monster its destination, because the player is running away. Maybe try something when playerPos != lastPlayerPos
    }
    protected override void FixedUpdateState(MonsterStateMachine monster) { }
    protected override void ExitState(MonsterStateMachine monster) { }
}
