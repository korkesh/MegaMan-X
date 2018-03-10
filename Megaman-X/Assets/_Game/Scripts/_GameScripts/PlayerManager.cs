using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    //public enum playerFSM
    //{
    //    Idle,
    //    Running,
    //    Jumping,
    //    Falling,
    //    Climbing,
    //    Dashing,
    //    Sliding
    //}

    // a way to set up the current state and remember the previous state
    private IState currentState;
    private IState previousState;

    public void ChangeState(IState newState)
    {
        if (currentState != newState)
        {
            if (currentState != null) currentState.Exit();

            previousState = currentState;
            currentState = newState;

            currentState.Enter();

        }
    }


    public void ExecuteStateUpdate()
    {
        var runningState = currentState;
        if (runningState != null) runningState.Execute();
    }

    public void SwitchToPreviousState()
    {
        currentState.Exit();
        currentState = previousState;
        currentState.Enter();
    }

}
