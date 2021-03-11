using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public GameObject AnimationControl;

    private float speed = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(z < 0)
        {
            AnimationControl.GetComponent<PlayerAnimation>().BackwardsWalk();
        }
        else if(z == 0)
        {
            AnimationControl.GetComponent<PlayerAnimation>().Idle();
        }
        else if(z > 0)
        {
            AnimationControl.GetComponent<PlayerAnimation>().Walk();
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        bool jump = Input.GetKey(KeyCode.Space);
        if (jump && isGrounded)
        {
            AnimationControl.GetComponent<PlayerAnimation>().Jump();
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //player crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1f;
            //crouch = true
            AnimationControl.GetComponent<PlayerAnimation>().Crouch();
        }
        else
        {
            controller.height = 2f;
        }
    }
}
