using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerManager plManager;
    public float moveSpeed;
    public float activeJumpPower;

    public bool canMove;

    private Rigidbody2D rb;
    public Animator an;

    public bool isGrounded;
    public bool canClimb;
    public bool isClimbing;
    private bool isFalling;

    private float localSpeed;
    private float localJump;

    public Transform ladderPosition;


    public BoxCollider2D playerHitbox;
    public BoxCollider2D pLadderHitbox;

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







        if (!isClimbing)
        {
            rb.gravityScale = 1;
            //if right
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                //set PlayerFSM as Running
                plManager.ChangeState(PlayerManager.playerFSM.Running, gameObject, localSpeed, an, rb, 1);
               

            }
            //if left
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                //set PlayerFSM as Running
                plManager.ChangeState(PlayerManager.playerFSM.Running, gameObject, -localSpeed, an, rb, -1);
               
            }
            //if idle
            else
            {
                //set PlayerFSM as Idle
                plManager.ChangeState(PlayerManager.playerFSM.Idle, an, rb);

            }
        }

        if (isClimbing)
        {
            rb.gravityScale = 0;

            
            if (Input.GetAxisRaw("Vertical") > 0f)
            {
                Debug.Log("Going Up");
                plManager.ChangeState(PlayerManager.playerFSM.Climbing, an, rb, 1f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0f)
            {
                Debug.Log("Going Down");
                plManager.ChangeState(PlayerManager.playerFSM.Climbing, an, rb, -1f);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);

                plManager.ChangeState(PlayerManager.playerFSM.Idle, an, rb);

            }
            //plManager.ChangeState(PlayerManager.playerFSM.Climbing, an, rb, Input.GetAxisRaw("Vertical"));


        }


        if (Input.GetButtonDown("Jump") && canClimb)
        {
            plManager.ChangeState(PlayerManager.playerFSM.Idle, an, rb);

            isClimbing = !isClimbing;

            SwitchHitbox();

            transform.position = new Vector3(ladderPosition.position.x, transform.position.y, 0);


            if (!isClimbing)
            {

                an.Play("MegamanFall");
            }
        }
        else if (!canClimb)
        {

        


            if (Input.GetButtonDown("Jump") && isGrounded && !isFalling)
            {
                //set PlayerFSM as Jumping
                //plManager.ChangeState(new Jumping(an, rb, activeJumpPower));

                plManager.ChangeState(PlayerManager.playerFSM.Jumping, an, rb, activeJumpPower);

            }
        }
        an.SetBool("climbing", isClimbing);
        an.SetBool("grounded", isGrounded);
        an.SetBool("falling", isFalling);


        plManager.ExecuteStateUpdate();
        
        

    }

    public void SwitchHitbox()
    {

        playerHitbox.enabled = !playerHitbox.enabled;
        pLadderHitbox.enabled = !pLadderHitbox.enabled;
    }
}
