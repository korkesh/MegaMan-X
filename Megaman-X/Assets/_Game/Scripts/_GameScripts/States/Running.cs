using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : IState
{




    public void Enter()
    {
        Debug.Log("Enter Running");
    }

    public void Execute()
    {
        Debug.Log("--- Running --- ");
    }

    public void Exit()
    {
        Debug.Log("Exit Running");
    }

}
