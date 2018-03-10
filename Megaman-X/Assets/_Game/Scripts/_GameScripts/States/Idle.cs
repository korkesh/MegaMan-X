using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState {




    public void Enter()
    {
        Debug.Log("Enter Idle");
    }

    public void Execute()
    {
        Debug.Log("--- IDLE --- ");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle");
    }

}
