using UnityEngine;
using Random = UnityEngine.Random;

public class WanderingState : MonsterBaseState
{
    [SerializeField] private Transform[] walkPoints;
    private Vector3 _currentWalkPoint;
    private bool _isDoneWalking;

    protected override void EnterState(MonsterStateMachine monster)
    {
        IsValidToSwitch = true;

        UpdateAnimations(monster, "Idle-to-wandering", "IdelCrawl-to-Wanderingcrawl", true);
        
        var random = Random.Range(0, walkPoints.Length);
        _currentWalkPoint = walkPoints[random].position;
        monster.Agent.SetDestination(_currentWalkPoint);
    }

    protected override void UpdateState(MonsterStateMachine monster)
    {
        // UpdateAnimations(monster, "Wandering", "Wandering-crawl"); //todo: check voor wanderings naar elkaar

        var currentPos = new Vector2(transform.position.x, transform.position.z);
        var targetPos = new Vector2(_currentWalkPoint.x, _currentWalkPoint.z);

        if (currentPos == targetPos) monster.SwitchState(monster.idleState);
    }
    protected override void FixedUpdateState(MonsterStateMachine monster) { }

    protected override void ExitState(MonsterStateMachine monster) { }
}
