using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerControllerModern : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 7f;

    private Animator anim;
    private Rigidbody rb;
    private bool isGrounded;

    public Transform cameraTransform;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Oculta el cursor y lo centra
    }

    void Update()
    {
        Move();
        HandleJump();
        //Debug.Log($"Rigidbody Velocity: {rb.velocity}");

    }

    void Move()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Debug.Log($"Input Horizontal: {h}, Vertical: {v}");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Cámara -> dirección relativa
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationVelocity, 0.1f);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            Vector3 velocity = moveDir.normalized * movementSpeed;
            velocity.y = rb.velocity.y;
            //Debug.Log($"Calculated Velocity: {velocity}");
            rb.velocity = velocity;
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        anim.SetFloat("VelX", h);
        anim.SetFloat("VelY", v);
    }



    private float rotationVelocity;

    void HandleJump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.2f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("Jumping", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else if (isGrounded)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Fall", false);
        }
        else
        {
            anim.SetBool("Fall", true);
        }
    }
}
