using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoCharacter : MonoBehaviour
{
    private float speed = 3;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator animator;
    public float dir;
    public float verDir;
    public bool rechts, links, unten, oben;
    public bool noWeapon, gun, sword, trident;
    public GameObject hGun;
    // Start is called before the first frame update
    void Start()
    {
        // Application.targetFrameRate = 60;
        //noWeapon = true;
        gun = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir = Input.GetAxis("Horizontal");
        verDir = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(0, 0);
        if (noWeapon)
        {
            gun = false;
            sword = false;
            trident= false;
           // hGun.SetActive(false);
            if (dir == 0 && verDir == 0)
            {
                if (oben)
                {
                    animator.Play("obenIdle");
                }
                if (unten)
                {
                    animator.Play("untenIdle");
                }
                if (links || unten && links || oben && links)
                {
                    animator.Play("linksIdle");
                }
                if (rechts || unten && rechts || oben && rechts)
                {
                    animator.Play("rechtsIdle");
                }
            }
            else if (dir > 0 && verDir < 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                // animator.SetFloat("Speed", rb.velocity.x);
                // animator.SetFloat("UpperSpeed", 0);
                // animator.SetBool("DoesWalkRight", true);
                animator.Play("rechts_walk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir > 0 && verDir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                // animator.SetFloat("Speed", rb.velocity.x);
                // animator.SetFloat("UpperSpeed", 0);
                // animator.SetBool("DoesWalkRight", true);
                animator.Play("rechts_walk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                //animator.SetFloat("Speed", rb.velocity.x);
                //animator.SetFloat("UpperSpeed", 0);
                //animator.SetBool("DoesWalkLeft", true);
                animator.Play("linksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir > 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                //animator.SetFloat("Speed", rb.velocity.x);
                //animator.SetFloat("UpperSpeed", 0);
                //animator.SetBool("DoesWalkLeft", true);
                animator.Play("linksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                // animator.SetFloat("Speed", rb.velocity.x);
                // animator.SetFloat("UpperSpeed", 0);
                // animator.SetBool("DoesWalkRight", true);
                animator.Play("rechts_walk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;

            }
            else if (dir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                //animator.SetFloat("Speed", rb.velocity.x);
                //animator.SetFloat("UpperSpeed", 0);
                //animator.SetBool("DoesWalkLeft", true);
                animator.Play("linksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;

            }
            else if (verDir > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                // animator.SetFloat("UpperSpeed", rb.velocity.y);
                // animator.SetFloat("Speed", 0);
                // animator.SetBool("DoesWalkUp", true);
                animator.Play("obelWalk");
                rechts = false;
                links = false;
                oben = true;
                unten = false;

            }
            else if (verDir < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                // animator.SetFloat("UpperSpeed", rb.velocity.y);
                // animator.SetFloat("Speed", 0);
                // animator.SetBool("walkDown", true);
                animator.Play("untenWalk");
                rechts = false;
                links = false;
                oben = false;
                unten = true;
            }
        }
        if (gun)
        {

            noWeapon = false;
            sword = false;
            trident = false;
            if (dir == 0 && verDir == 0)
            {
                if (oben)
                {
                    animator.Play("gunObenIdle");
                }
                if (unten)
                {
                    animator.Play("gunUntenIdle");
                }
                if (links || unten && links || oben && links)
                {
                    animator.Play("gunLinksIdle");
                }
                if (rechts || unten && rechts || oben && rechts)
                {
                    animator.Play("gunRechtsIdle");
                }
            }
            else if (dir > 0 && verDir < 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                // animator.SetFloat("Speed", rb.velocity.x);
                // animator.SetFloat("UpperSpeed", 0);
                // animator.SetBool("DoesWalkRight", true);
                animator.Play("gunRechtsWalk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir > 0 && verDir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                // animator.SetFloat("Speed", rb.velocity.x);
                // animator.SetFloat("UpperSpeed", 0);
                // animator.SetBool("DoesWalkRight", true);
                animator.Play("gunRechtsWalk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                //animator.SetFloat("Speed", rb.velocity.x);
                //animator.SetFloat("UpperSpeed", 0);
                //animator.SetBool("DoesWalkLeft", true);
                animator.Play("gunLinksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir < 0 && verDir > 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(rb.velocity.x, speed);
                //animator.SetFloat("Speed", rb.velocity.x);
                //animator.SetFloat("UpperSpeed", 0);
                //animator.SetBool("DoesWalkLeft", true);
                animator.Play("gunLinksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;
            }
            else if (dir > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                // animator.SetFloat("Speed", rb.velocity.x);
                // animator.SetFloat("UpperSpeed", 0);
                // animator.SetBool("DoesWalkRight", true);
                animator.Play("gunRechtsWalk");
                rechts = true;
                links = false;
                oben = false;
                unten = false;

            }
            else if (dir < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                //animator.SetFloat("Speed", rb.velocity.x);
                //animator.SetFloat("UpperSpeed", 0);
                //animator.SetBool("DoesWalkLeft", true);
                animator.Play("gunLinksWalk");
                rechts = false;
                links = true;
                oben = false;
                unten = false;

            }
            else if (verDir > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                // animator.SetFloat("UpperSpeed", rb.velocity.y);
                // animator.SetFloat("Speed", 0);
                // animator.SetBool("DoesWalkUp", true);
                animator.Play("gunObenWalk");
                rechts = false;
                links = false;
                oben = true;
                unten = false;

            }
            else if (verDir < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                // animator.SetFloat("UpperSpeed", rb.velocity.y);
                // animator.SetFloat("Speed", 0);
                // animator.SetBool("walkDown", true);
                animator.Play("gunUntenWalk");
                rechts = false;
                links = false;
                oben = false;
                unten = true;
            }
        }


    }
}
