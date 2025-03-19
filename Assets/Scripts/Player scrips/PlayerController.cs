using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 5.0f;
    public float RotationSpeed = 200.0f;
    private Animator Anim;
    public float x, y;
    public float JumpForce = 8.0f;
    private bool isGrounded = true;
    private float timeInAir = 0.0f;

    private Rigidbody rgbd;

    void Start()
    {
        Anim = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * RotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * MovementSpeed);
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Anim.SetFloat("VelX", x);
        Anim.SetFloat("VelY", y);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        if (isGrounded)
        {
            Anim.SetBool("Jumping", false);
            Anim.SetBool("Fall", false);
            timeInAir = 0.0f;

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
    }
        else
        {
            timeInAir += Time.deltaTime;

            if (timeInAir >= 0.8f)
            {
                Anim.SetBool("Fall", true);
            }
        }


    }

    public void Jump()
    {
        Anim.SetBool("Jumping", true);
        rgbd.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);      
    }
}
