public abstract class GameBaseState : BaseState
{
    #region BaseState to GameState

    public override void EnterState(StateMachine entity)
    {
        base.EnterState(Parent);
        EnterState((GameStateManger) Parent);
    }

    public override void UpdateState(StateMachine entity) => UpdateState((GameStateManger)Parent);
    public override void FixedUpdateState(StateMachine entity) => FixedUpdateState((GameStateManger)Parent);
    public override void ExitState(StateMachine entity) => ExitState((GameStateManger)Parent);

    #endregion

    
    #region Functions called by state's

    protected abstract void EnterState(GameStateManger enemy);
    protected abstract void UpdateState(GameStateManger enemy);
    protected abstract void FixedUpdateState(GameStateManger enemy);
    protected abstract void ExitState(GameStateManger enemy);

    #endregion
}
