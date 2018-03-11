using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState {

    private Animator myAn;
    private Rigidbody2D myRb;

    public Idle( Animator an, Rigidbody2D rb)
    {
       
        myAn = an;
        myRb = rb;
    }

    public void passValues(Animator an, Rigidbody2D rb)
    {
       
        myAn = an;
        myRb = rb;
    }

public void Enter()
    {
        Debug.Log("Enter Idle");
    }

    public void Execute()
    {
        Debug.Log("--- IDLE --- ");
        myRb.velocity = new Vector2(0, myRb.velocity.y);

        myAn.SetFloat("speed", 0);
    }

    public void Exit()
    {
        Debug.Log("Exit Idle");
    }

}
