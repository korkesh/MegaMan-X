using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : IState
{
    public void Enter()
    {
        Debug.Log("Enter Firing");
    }

    public void Execute()
    {
        Debug.Log("-- Firing --");
    }

    public void Exit()
    {
        Debug.Log("Exit Firing");
    }
    public string CheckState()
    {
        return "Firing";
    }
}
