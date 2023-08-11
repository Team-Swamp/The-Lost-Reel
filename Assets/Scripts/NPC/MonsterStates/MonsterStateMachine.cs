using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class MonsterStateMachine : StateMachine
{
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public WanderingState wanderingState;
    [HideInInspector] public SeekingState seekingState;
    [HideInInspector] public ChasingState chasingState;
    [HideInInspector] public KillState killState;

    [Header("Monster StateMachine")]
    [SerializeField] private float foundPlayerDistance = 2;
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [SerializeField] private CeilingDetection ceilingDetection;

    [Header("Unity events")]
    public UnityEvent onPlayerFound = new UnityEvent();
    public UnityEvent onSwitchToWalkingState = new UnityEvent();
    public UnityEvent startChasing = new UnityEvent();

    private new void Awake()
    {
        idleState = GetComponent<IdleState>();
        wanderingState = GetComponent<WanderingState>();
        seekingState = GetComponent<SeekingState>();
        chasingState = GetComponent<ChasingState>();
        killState = GetComponent<KillState>();

        base.Awake();
    }

    private new void Update()
    {
        base.Update();

        var foundPlayer = currentState != seekingState && GetDistanceBetweenPlayer(foundPlayerDistance);
        var isChasingPlayer = currentState != chasingState && GetDistanceBetweenPlayer(foundPlayerDistance);
        var isKillingPlayer = currentState != killState && GetDistanceBetweenPlayer(foundPlayerDistance);
        
        if (foundPlayer && isChasingPlayer && isKillingPlayer) SwitchState(seekingState);
    }

    public bool GetDistanceBetweenPlayer(float margin)
    {
        var distanceBeTweenPlayer = transform.position - Player.transform.position;
        return distanceBeTweenPlayer.magnitude < margin;
    }

    public string GetCrawlingState(string standingAnimation, string crawlingAnimation)
    {
        var targetAnimation = ceilingDetection.IsTouchingCeiling ? crawlingAnimation : standingAnimation;
        return targetAnimation;
    }
}
