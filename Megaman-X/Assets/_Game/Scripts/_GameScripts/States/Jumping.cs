﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : IState {


    private float mySpeed;
    private float myJumpPower;
    private Animator myAn;
    private Rigidbody2D myRb;

    public Jumping( Animator an, Rigidbody2D rb, float jumpPower)
    {
        myAn = an;
        myRb = rb;
        myJumpPower = jumpPower;
    }
    public void passValues( Animator an, Rigidbody2D rb, float jumpPower)
    {
        myAn = an;
        myRb = rb;
        myJumpPower = jumpPower;
    }

    public void Enter()
    {
        Debug.Log("Enter Jumping");
    }

    public void Execute()
    {
        Debug.Log("-- Jumping --");
        myRb.velocity = new Vector2(myRb.velocity.x, myJumpPower);

    }

    public void Exit()
    {
        Debug.Log("Exit Jumping");
    }

}