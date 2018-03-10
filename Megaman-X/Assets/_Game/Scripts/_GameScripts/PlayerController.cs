using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerManager plManager;
    public float moveSpeed;
    public float activeJumpPower;

    public bool canMove;

    private Rigidbody2D rb;
    private Animator an;

    public bool isGrounded;
    private bool isFalling;

    


	// Use this for initialization
	void Start () {
        plManager = new PlayerManager();
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //if player cannot move
        if (!canMove)
        {
            return;
        }

        //if grounded or falling
        if (rb.velocity.y > 0)
        {
            //isGrounded = false;
            isFalling = false;
        }
        else if (rb.velocity.y < 0)
        {
            //isGrounded = false;
            isFalling = true;
        }
        else
        {
            //isGrounded = true;
            isFalling = false;
        }



        //if right
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            //set PlayerFSM as Running
            plManager.ChangeState(new Running(gameObject, moveSpeed, an, rb, 1));

        }
        //if left
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            //set PlayerFSM as Running
            plManager.ChangeState(new Running(gameObject, -moveSpeed, an, rb, -1));

        }
        //if idle
        else
        {
            //set PlayerFSM as Idle
            plManager.ChangeState(new Idle(gameObject, 0, an, rb));

        }


        if (Input.GetButtonDown("Jump") && isGrounded && !isFalling)
        {
            plManager.ChangeState(new Jumping(gameObject, rb.velocity.x, an, rb, activeJumpPower));
        }


        plManager.ExecuteStateUpdate();





        


        an.SetBool("grounded", isGrounded);
        an.SetBool("falling", isFalling);

    }
}
