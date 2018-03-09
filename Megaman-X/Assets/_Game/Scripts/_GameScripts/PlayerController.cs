using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    public bool canMove;

    private Rigidbody2D rb;
    public Animator an;
	// Use this for initialization
	void Start () {
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

        //if right
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);

            //set PlayerFSM as Running

        }
        //if left
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);

            //set PlayerFSM as Running

        }
        //if idle
        else
        {
            //set PlayerFSM as Idle

            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        an.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        an.SetBool("grounded", true);

    }
}
