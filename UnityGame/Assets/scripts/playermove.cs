using UnityEngine;

public class playermove : MonoBehaviour
{
    public CharacterController controller;

    public Animator animator;
    public float speed = 12f;
    public float gravity = -8.9f;
    public float jumppower = 4f;
    public Transform groundch;
    public float groundDistanse = 1f;
    public LayerMask groundMask;
    public float x;
    public float z;
    public bool isidle = false;
    public bool isexitidle = false;
    public bool isrunning= false;

    Vector3 velocity;
    public bool isgrounded;

    void SpeedEqual12()
    {
        isexitidle = true;
    }


    void Update()
    {
        isgrounded = Physics.CheckSphere(groundch.position, groundDistanse, groundMask);
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
                isexitidle = false;
            }
        }
        else
        {
            if ((animator.GetCurrentAnimatorStateInfo(0).IsName("idle_Loop_") ||
                animator.GetCurrentAnimatorStateInfo(0).IsName("idle_Exit")) &&
                !isexitidle)
            {
                animator.Play("idle_Exit");
                Invoke("SpeedEqual12", 0.8f);
            }
            else if(isexitidle && !isrunning)
            {
                animator.Play("move");
            }
            isidle = false;
        }


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isrunning = true;
            speed = 18f;
            animator.Play("run");
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
            animator.Play("move");
            isrunning = false;
        }

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumppower * 2f * -gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
