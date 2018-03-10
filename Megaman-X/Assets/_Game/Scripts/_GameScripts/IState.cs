using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    //interface for IStates 
    void Enter(); //Enter State
    void Execute(); //Execute State
    void Exit(); //Exit State
}
