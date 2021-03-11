using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;  //contains animator object

    void Start()
    {
        //moving speed of player (walking or running) determined by
        anim = GetComponent<Animator>();
    }


    //moving speed of player (walking or running) determined by
    //float value passed in from PlayerController script
    public void playerMove(float moveSpeed)
    {
        anim.SetFloat("Speed", moveSpeed);
    }

    public void Die()
    {
        anim.SetTrigger("Die");
    }

    public void Idle()
    {
        anim.SetBool("idle", true);
        anim.SetBool("walk", false);
        anim.SetBool("backwards", false);
        anim.SetBool("crouch", false);
        
    }
    public void Walk()
    {
        anim.SetBool("walk", true);
        anim.SetBool("idle", false);
    }

    public void BackwardsWalk()
    {
        anim.SetBool("backwards", true);
    }

    public void Jump()
    {
        anim.SetTrigger("jump");
    }

    public void Crouch()
    {
        anim.SetBool("crouch", true);
    }

    

}
