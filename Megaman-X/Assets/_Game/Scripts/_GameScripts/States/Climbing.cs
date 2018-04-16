using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : IState {


    private Animator myAn;
    private Rigidbody2D myRb;
    private float myDir;

    public Climbing(Animator an, Rigidbody2D rb, float dir)
    {
        myAn = an;
        myRb = rb;
        myDir = dir;
    }
    public void PassValues(Animator an, Rigidbody2D rb, float dir)
    {
        myAn = an;
        myRb = rb;
        myDir = dir;
    }


    public void Enter()
    {
        Debug.Log("Enter Climbing");
       
    }

    public void Execute()
    {


        if (myDir > 0) myAn.SetTrigger("ForwardClimb");
        else if (myDir < 0) myAn.SetTrigger("BackwardClimb");

        myRb.velocity = new Vector2(0, myDir);


    }

    public void Exit()
    {
        Debug.Log("Exit Climbing");
    }

    public string CheckState()
    {
        return "Climbing";
    }
}
