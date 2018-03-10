﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState {

    private float mySpeed;
    private Animator myAn;
    private GameObject myOwner;
    private Rigidbody2D myRb;

    public Idle(GameObject owner, float speed, Animator an, Rigidbody2D rb)
    {
        myOwner = owner;
        mySpeed = speed;
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

        myAn.SetFloat("speed", mySpeed);
    }

    public void Exit()
    {
        Debug.Log("Exit Idle");
    }

}
