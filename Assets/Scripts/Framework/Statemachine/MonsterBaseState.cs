using UnityEngine;

public abstract class MonsterBaseState : BaseState
{
    #region BaseState to MonsterState

    public override void EnterState(StateMachine entity)
    {
        base.EnterState(Parent);
        EnterState((MonsterStateMachine) Parent);
    }

    public override void UpdateState(StateMachine entity) => UpdateState((MonsterStateMachine)Parent);
    public override void FixedUpdateState(StateMachine entity) => FixedUpdateState((MonsterStateMachine)Parent);
    public override void ExitState(StateMachine entity) => ExitState((MonsterStateMachine)Parent);

    #endregion

    
    #region Functions called by state's

    protected abstract void EnterState(MonsterStateMachine enemy);
    protected abstract void UpdateState(MonsterStateMachine enemy);
    protected abstract void FixedUpdateState(MonsterStateMachine enemy);
    protected abstract void ExitState(MonsterStateMachine enemy);

    #endregion
}
