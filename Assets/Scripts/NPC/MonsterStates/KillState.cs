using System.Collections;
using UnityEngine;

public class KillState : MonsterBaseState
{
    [SerializeField] private GameObject killCam;
    [SerializeField] private float animationTime = 8;
    
    protected override void EnterState(MonsterStateMachine monster)
    {
        killCam.SetActive(true);
        Destroy(monster.Player);
        monster.Animator.Play("JumpScare");
        monster.onStartKilling?.Invoke();
        StartCoroutine(AnimationsDone(monster));
    }

    protected override void UpdateState(MonsterStateMachine monster) { }

    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster) { }

    private IEnumerator AnimationsDone(MonsterStateMachine monster)
    {
        yield return new WaitForSeconds(animationTime);
        monster.onKilled?.Invoke();
    }
}
