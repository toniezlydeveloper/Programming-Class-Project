using System;

public abstract class State
{
    public virtual void OnEnter()
    {
            
    }

    public virtual void OnExit()
    {
            
    }

    public virtual Type Update()
    {
        return null;
    }
}