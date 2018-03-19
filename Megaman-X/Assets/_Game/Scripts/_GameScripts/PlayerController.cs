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

    private float localSpeed;
    private float localJump;

	// Use this for initialization
	void Start () {

        localJump = activeJumpPower;
        localSpeed = moveSpeed;

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


        an.SetBool("grounded", isGrounded);
        an.SetBool("falling", isFalling);



        //if right
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            //set PlayerFSM as Running
            //plManager.ChangeState(new Running(gameObject, moveSpeed, an, rb, 1));
            plManager.ChangeState(PlayerManager.playerFSM.Running, gameObject, localSpeed, an, rb, 1);
            //rb.velocity = new Vector2(localSpeed, rb.velocity.y);
            //transform.localScale = new Vector3(1, 1f, 1f);

        }
        //if left
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            //set PlayerFSM as Running
            //plManager.ChangeState(new Running(gameObject, -moveSpeed, an, rb, -1));
            plManager.ChangeState(PlayerManager.playerFSM.Running, gameObject, -localSpeed, an, rb, -1);
            //rb.velocity = new Vector2(-localSpeed, rb.velocity.y);
            //transform.localScale = new Vector3(-1, 1f, 1f);
        }
        //if idle
        else
        {
            //set PlayerFSM as Idle
            //plManager.ChangeState(new Idle(an, rb));
            plManager.ChangeState(PlayerManager.playerFSM.Idle, an, rb);
            //rb.velocity = new Vector2(0, rb.velocity.y);

        }


        if (Input.GetButtonDown("Jump") && isGrounded && !isFalling)
        {
            //set PlayerFSM as Jumping
            //plManager.ChangeState(new Jumping(an, rb, activeJumpPower));
            plManager.ChangeState(PlayerManager.playerFSM.Jumping, an, rb, activeJumpPower);
        }


        plManager.ExecuteStateUpdate();






        //an.SetFloat("speed", Mathf.Abs(rb.velocity.x));


        

    }
}
