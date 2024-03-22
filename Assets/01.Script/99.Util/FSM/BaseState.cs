using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BaseState<T> where T : Type
{
    private BaseStateMachine<T> stateMachine;

    public void SetStateMachine(BaseStateMachine<T> stateMachine) 
    {
        this.stateMachine = stateMachine;
    }

    protected void ChangeState(T stateEnum)
    {
        stateMachine.ChangeState(stateEnum);
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Transition();
    public virtual void Update() { }
    public virtual void LateUpdate() { }
    public virtual void FixedUpdate() { }

}
