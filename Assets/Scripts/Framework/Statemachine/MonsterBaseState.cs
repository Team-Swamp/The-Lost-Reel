using UnityEngine;

public abstract class MonsterBaseState : BaseState
{
    protected bool IsCrawling;
    protected string CurrentAnimationToPlay;
    
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
        var crawlingState = monster.GetCrawlingState(standingAnimation, crawlingAnimation);
        Debug.Log(crawlingState);
        
        if (CurrentAnimationToPlay != crawlingState.Item1) CurrentAnimationToPlay = crawlingState.Item1;
        if (IsCrawling != crawlingState.Item2) IsCrawling = crawlingState.Item2;
        
        monster.Animator.Play(CurrentAnimationToPlay);
    }
}
