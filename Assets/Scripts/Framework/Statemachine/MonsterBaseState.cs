using UnityEngine;

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

    protected void UpdateAnimations(MonsterStateMachine monster, string standingAnimation, string crawlingAnimation, bool isTransition = false)
    {
        // Waarom de transition animations niet werken is waarschijnlijk omdat ze overwriten worden daar de constant animations, like waar ze naartoe gaan.
        // Dit is op te lossen met de bool isTransition, alleen die check moet gemaakt worden in dit script.
        
        // Als dit niet het probleem is, spendeer niet meer dan 2 uur hier aan, maakt niet extreem veel uit.

        var (targetAnimation, isCrawling) = monster.GetCrawlingState(standingAnimation, crawlingAnimation);

        if (_currentAnimationToPlay != targetAnimation) _currentAnimationToPlay = targetAnimation;
        if (_isCrawling != isCrawling) _isCrawling = isCrawling;
        
        monster.Animator.Play(_currentAnimationToPlay);
        Debug.Log(_currentAnimationToPlay);
    }
}
