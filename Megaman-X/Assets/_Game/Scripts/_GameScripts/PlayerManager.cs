using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public enum playerFSM
    {
        Idle,
        Running,
        Jumping,
        Climbing,
        Dashing,
        Sliding
    }

    Idle idle;
    Running running;
    Jumping jumping;
    Climbing climbing;
    
    
    
    // a way to set up the current state and remember the previous state
    private IState currentState;
    private IState previousState;

    private playerFSM currentPFSM;
    private playerFSM previousPFSM;

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

    public string CheckRunningState()
    {
        if (currentState != null)
        {
            return currentState.CheckState();

        }
        return "No State";

    }

    public void ChangeState(playerFSM newPFSM, params object[] items)
    {
        if (newPFSM == currentPFSM)
        {
            return;
        }

        previousPFSM = currentPFSM;
        currentPFSM = newPFSM;
        IState newState = null;

        switch (newPFSM)
        {
            case playerFSM.Running:
                if (running == null) running = new Running((GameObject)items[0], (float)items[1], (Animator)items[2], (Rigidbody2D)items[3], (int)items[4]);
                else running.PassValues((GameObject)items[0], (float)items[1], (Animator)items[2], (Rigidbody2D)items[3], (int)items[4]);
                newState = running;
                break;
            case playerFSM.Jumping:
                if (jumping == null) jumping = new Jumping((Animator)items[0], (Rigidbody2D)items[1], (float)items[2]);
                else jumping.PassValues((Animator)items[0], (Rigidbody2D)items[1], (float) items[2]);
                newState = jumping;
                break;
            case playerFSM.Climbing:
                if (climbing == null) climbing = new Climbing((Animator)items[0], (Rigidbody2D)items[1], (float)items[2]);
                else climbing.PassValues((Animator)items[0], (Rigidbody2D)items[1], (float)items[2]);
                Debug.Log(items[2] + " === ");
                newState = climbing;
                break;
            case playerFSM.Dashing:
                break;
            case playerFSM.Sliding:
                break;
            case playerFSM.Idle:
                if (idle == null) idle = new Idle((Animator)items[0], (Rigidbody2D)items[1]);
                else idle.PassValues((Animator)items[0], (Rigidbody2D)items[1]);
                newState = idle;
                break;
        }

        


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
