using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public GameObject AnimationControl;

    //static Animator anim;

    private float speed = 2f;
    public float gravity = -10f;
    public float jumpHeight = 0.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool crouch;

    //colliders for crouching and standing
    CapsuleCollider stand_collider;
    SphereCollider crouch_collider;

    private void Start()
    {
        //fetch GameObject's colliders
        stand_collider = GetComponent<CapsuleCollider>();
        crouch_collider = GetComponent<SphereCollider>();
    }


    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        velocity.y += gravity * Time.deltaTime;


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        bool jump = Input.GetKey(KeyCode.Space);
        if (jump && isGrounded)
        {
            AnimationControl.GetComponent<PlayerAnimation>().Jump();
            //velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        }

        controller.Move(velocity * Time.deltaTime);

        //player crouch
        if (Input.GetKey(KeyCode.LeftShift))
        {
            crouch_collider.enabled = true;
            stand_collider.enabled = false;

            AnimationControl.GetComponent<PlayerAnimation>().Crouch();


            //crouch = true;
            if (z < 0)
            {
                AnimationControl.GetComponent<PlayerAnimation>().CrouchBackwardsWalk();
            }
            
            if (z > 0)
            {
                AnimationControl.GetComponent<PlayerAnimation>().CrouchWalk();
            }


        }
        
        else
        {
            //crouch = false;
            crouch_collider.enabled = false;
            stand_collider.enabled = true;
            //AnimationControl.GetComponent<PlayerAnimation>().Idle();

            AnimationControl.GetComponent<PlayerAnimation>().Idle();

            if (z < 0)
            {
                AnimationControl.GetComponent<PlayerAnimation>().BackwardsWalk();
            }
            else if (z > 0)
            {
                AnimationControl.GetComponent<PlayerAnimation>().Walk();
            }
        }
        

    }

}
