using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    protected StateMachine Parent;
    public bool IsValidToSwitch { get; protected set; }

    public void SetParent(StateMachine targetMachine) => Parent = targetMachine;

    public virtual void EnterState(StateMachine stateMachine) => IsValidToSwitch = false;
    public abstract void UpdateState(StateMachine stateMachine);
    public abstract void FixedUpdateState(StateMachine stateMachine);
    public abstract void ExitState(StateMachine stateMachine);
}
