using System.Collections;
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
    [SerializeField, Range(1, 60)] private float playerCanBeFoundTime = 7.5f;
    [SerializeField, Range(1, 60)] private float growlTime = 30f;
    [field: SerializeField] public Transform[] WalkPoints { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [SerializeField] private CeilingDetection ceilingDetection;
    [SerializeField] private SoundEffectsController musicController;

    [Header("Unity events")]
    public UnityEvent onPlayerFound = new UnityEvent();
    public UnityEvent onSwitchToWalkingState = new UnityEvent();
    public UnityEvent onSwitchingToIdle = new UnityEvent();
    public UnityEvent startChasing = new UnityEvent();
    public UnityEvent onStartKilling = new UnityEvent();
    public UnityEvent onKilled = new UnityEvent();

    private bool _playerCanBeFound = true;
    private bool _hasGrowl;
    private float _growlTimer;

    private new void Awake()
    {
        idleState = GetComponent<IdleState>();
        wanderingState = GetComponent<WanderingState>();
        seekingState = GetComponent<SeekingState>();
        chasingState = GetComponent<ChasingState>();
        killState = GetComponent<KillState>();

        _growlTimer = growlTime;
        
        base.Awake();
    }

    private new void Update()
    {
        base.Update();

        UpdateGrowlTime();

        if (!_playerCanBeFound) return;

        var foundPlayer = currentState != seekingState && GetDistanceBetweenPlayer(foundPlayerDistance);
        var canStartSeeking = foundPlayer && currentState != idleState && currentState != chasingState && currentState != killState;

        if (!canStartSeeking) return;
        
        _playerCanBeFound = false;
        SwitchState(seekingState);
    }

    public bool GetDistanceBetweenPlayer(float margin)
    {
        if (!Player) return false;
        
        var distanceBeTweenPlayer = transform.position - Player.transform.position;
        return distanceBeTweenPlayer.magnitude < margin;
    }

    public (string, bool) GetCrawlingState(string standingAnimation, string crawlingAnimation)
    {
        var targetAnimation = ceilingDetection.IsTouchingCeiling ? crawlingAnimation : standingAnimation;
        return (targetAnimation, ceilingDetection.IsTouchingCeiling);
    }

    public IEnumerator SetPlayerCanBeFound()
    {
        yield return new WaitForSeconds(playerCanBeFoundTime);
        _playerCanBeFound = true;
    }

    private void UpdateGrowlTime()
    {
        if (!_hasGrowl)
        {
            musicController.PlayRandomGrowl();
            _hasGrowl = true;
            _growlTimer = growlTime;
        }
        else if (_growlTimer <= 0) _hasGrowl = false;
        else
        {
            _growlTimer -= Time.deltaTime;
        }
    }
}
