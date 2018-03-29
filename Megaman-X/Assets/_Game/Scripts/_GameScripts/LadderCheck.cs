using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderCheck : MonoBehaviour {

    public PlayerController pl;

	// Use this for initialization
	void Start () {
        pl = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Debug.Log("I am on a Ladder");
            pl.canClimb = true;
            pl.ladderPosition = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Debug.Log("I am not on a Ladder");
            pl.canClimb = false;
        }
    }

}
