using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public CharacterController controller;

    public Animator animator;
    public float speed = 12f;
    public float gravity = -8.9f;
    public float jumppower = 4f;
    public Transform groundch;
    public float groundDistanse = 0.4f;
    public LayerMask groundMask;
    public float x;
    public float z;
    bool isidle = false;

    Vector3 velocity;
    bool isgrounded;
    void Update()
    {
        isgrounded = true;
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (x == 0f && z == 0f)
        {
            if (!isidle)
            {
                animator.Play("idle_entry");
                isidle = true;
            }
        }
        else
        {
            animator.Play("move");
            isidle = false;
        }


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 18f;
            animator.Play("naruto");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
            animator.Play("move");
        }
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumppower * 2f * -gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
