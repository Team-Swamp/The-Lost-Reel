using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public WanderingState wanderingState;

    private new void Awake()
    {
        idleState = GetComponent<IdleState>();
        wanderingState = GetComponent<WanderingState>();
        
        base.Awake();
    }

    private new void Update() => base.Update();
}
