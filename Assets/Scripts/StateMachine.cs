using System;
using System.Collections.Generic;

public class StateMachine
{
    private State currentState;
    private Dictionary<Type, State> states = new Dictionary<Type, State>();

    public StateMachine(State firstState)
    {
        SetNextState(firstState);
    }

    public void Tick()
    {
        Type nextStateKey = currentState?.Update();

        if (nextStateKey == null)
        {
            return;
        }

        if (states.TryGetValue(nextStateKey, out State nextState))
        {
            SetNextState(nextState);
        }
    }

    public void AddTransition(Type key, State state)
    {
        states.Add(key, state);
    }

    private void SetNextState(State nextState)
    {
        currentState?.OnExit();
        nextState.OnEnter();

        currentState = nextState;
    }
}