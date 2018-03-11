using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : IState
{
    private float mySpeed;
    private Animator myAn;
    private GameObject myOwner;
    private Rigidbody2D myRb;
    private int myDirection;

    public Running(GameObject owner, float speed, Animator an, Rigidbody2D rb, int direction)
    {
        myOwner = owner;
        mySpeed = speed;
        myAn = an;
        myRb = rb;
        myDirection = direction;
    }
    public void passValues(GameObject owner, float speed, Animator an, Rigidbody2D rb, int direction)
    {
        myOwner = owner;
        mySpeed = speed;
        myAn = an;
        myRb = rb;
        myDirection = direction;
    }

    public void Enter()
    {
        Debug.Log("Enter Running");
    }

    public void Execute()
    {
        Debug.Log("--- Running --- ");
        myRb.velocity = new Vector2(mySpeed, myRb.velocity.y);
        myOwner.transform.localScale = new Vector3(myDirection, 1f, 1f);

        myAn.SetFloat("speed", Mathf.Abs(myRb.velocity.x));

    }

    public void Exit()
    {
        Debug.Log("Exit Running");
    }

}
