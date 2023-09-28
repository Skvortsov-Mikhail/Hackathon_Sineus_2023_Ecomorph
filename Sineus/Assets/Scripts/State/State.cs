using UnityEngine;

public abstract class State : IState
{
    public CharacterMovement CharacterController;

    public State(CharacterMovement characterController)
    {
        CharacterController = characterController;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }
}
