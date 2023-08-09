using UnityEngine;
using UnityEngine.AI;

public class MonsterStateMachine : StateMachine
{
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public WanderingState wanderingState;
    [HideInInspector] public SeekingState seekingState;
    [HideInInspector] public ChasingState chasingState;

    [Header("Monster StateMachine")]
    [SerializeField] private float foundPlayerDistance = 2;
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public GameObject Player { get; private set; }

    private new void Awake()
    {
        idleState = GetComponent<IdleState>();
        wanderingState = GetComponent<WanderingState>();
        seekingState = GetComponent<SeekingState>();
        chasingState = GetComponent<ChasingState>();

        base.Awake();
    }

    private new void Update()
    {
        base.Update();

        var distanceBeTweenPlayer = transform.position - Player.transform.position;
        var foundPlayer = currentState != seekingState && distanceBeTweenPlayer.magnitude < foundPlayerDistance;
        var isChasingPlayer = currentState != chasingState && distanceBeTweenPlayer.magnitude < foundPlayerDistance;
        
        if (foundPlayer && isChasingPlayer) SwitchState(seekingState);
    }
}
