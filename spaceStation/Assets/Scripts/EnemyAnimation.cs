using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;  //contains animator object

    void Start()
    {
        //moving speed of player (walking or running) determined by
        anim = GetComponent<Animator>();
    }


    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    

}