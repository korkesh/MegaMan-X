///=====================================================================================
/// Author: Matt
/// Purpose: Handles the combat flow of the player; includes attacking, invicibility,
///          damage and death
///======================================================================================

using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    public GameObject weaponCollider;
    //public GameObject groundPoundCollider;
    public GameObject weaponParentObject;
    public GameObject weaponBackParentObject;

    public bool attacking;
    public bool damage;

    public float attackStart;
    public float attackLength;
    public float colliderLength;
    public float iframes;


    public AudioClip damageSound;

    // Use this for initialization
    void Start()
    {
        damage = false;
        weaponCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BeginAttack()
    {
        if(attacking || !Character_Manager.instance.toggleHammer)
        {
            return;
        }

        attacking = true;

        weaponParentObject.SetActive(true); // Turn hammer on
        weaponBackParentObject.SetActive(false); // Turn back hammer off

        // Attack animation
        gameObject.GetComponent<Animator>().SetBool("SideSwing", true);

        gameObject.GetComponent<Animator>().SetLayerWeight(1, 1);

        StartCoroutine(EnableCollider());
        StartCoroutine(DisableCollider());
        StartCoroutine(EndAttack());
    }

    public IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(attackStart);
        
        // Allow attacks to register damage
        weaponCollider.SetActive(true);
        damage = true;
    }

    public IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(colliderLength);

        // DisAllow attacks to register damage
        weaponCollider.SetActive(false);
        damage = false;

    }

    public IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(attackLength);

        attacking = false;
        weaponParentObject.SetActive(false); // Turn hammer off
        weaponBackParentObject.SetActive(true); // Turn back hammer on

        // Attack animation End
        gameObject.GetComponent<Animator>().SetBool("SideSwing", false);
        gameObject.GetComponent<Animator>().SetBool("DownSwing", false);

    }

    /* [DISABLED]
    public void BeginPound()
    {
        weaponParentObject.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("GroundPound", true);
        attacking = true;
        groundPoundCollider.SetActive(true);
    }

    public void EndPound()
    {
        weaponParentObject.SetActive(false);
        attacking = false;
        groundPoundCollider.SetActive(false);
        gameObject.GetComponent<Animator>().SetBool("GroundPound", false);
    }
    */

    // Turn on invincibilty
    public void DamageBegin()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(DamageEnd());

        gameObject.SendMessage("PlayAlt2");
    }

    // Turn off invincibility
    public IEnumerator DamageEnd()
    {
        yield return new WaitForSeconds(iframes);

        if (Character_Manager.instance != null)
        {
            //Debug.Log("Damage End");
            Character_Manager.instance.invincible = false;
        }
    }

    // Handle Death state
    public void GameOver()
    {
        if (UI_Manager.instance != null && Character_Manager.instance != null)
        {
            Character_Manager.instance.revivePlayer();
        }
    }
}
