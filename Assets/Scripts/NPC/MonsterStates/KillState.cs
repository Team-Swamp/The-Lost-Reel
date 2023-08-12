public class KillState : MonsterBaseState
{
    protected override void EnterState(MonsterStateMachine monster)
    {
        monster.Animator.Play("JumpScare");
        monster.isKilling?.Invoke();
    }

    protected override void UpdateState(MonsterStateMachine monster) { }

    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster) { }
}
