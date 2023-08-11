public abstract class MonsterBaseState : BaseState
{
    private bool _isCrawling;
    private string _currentAnimationToPlay;
    
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

    protected abstract void EnterState(MonsterStateMachine monster);
    protected abstract void UpdateState(MonsterStateMachine monster);
    protected abstract void FixedUpdateState(MonsterStateMachine monster);
    protected abstract void ExitState(MonsterStateMachine monster);

    #endregion

    protected void UpdateAnimations(MonsterStateMachine monster, string standingAnimation, string crawlingAnimation)
    {
        var (targetAnimation, isCrawling) = monster.GetCrawlingState(standingAnimation, crawlingAnimation);

        if (_currentAnimationToPlay != targetAnimation) _currentAnimationToPlay = targetAnimation;
        if (_isCrawling != isCrawling) _isCrawling = isCrawling;
        
        monster.Animator.Play(_currentAnimationToPlay);
    }
}
