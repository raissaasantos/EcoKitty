using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick joystickMovement;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //Grab references for rigigbody and animator from object
        body = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //body.linearVelocity = new Vector2 (horizontalInput * speed, body.linearVelocity.y);

        //Movement with joystick
        float horizontalInput = joystickMovement.Horizontal;
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        //Flip player when moving right-left
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }

        // if (Input.GetKey(KeyCode.Space) && grounded)
        //{
       //     Jump();
        //}

        //Set animator parameters
        anim.SetBool("running", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    public void Jump()
    {
        //body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        //grounded = false;
        if (grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            grounded = false;
            anim.SetBool("grounded", grounded);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Garbage"))
        {
            // The object we collided with has the "Garbage" tag
            GarbageCounter.Instance.AddGarbage();
            Destroy(other.gameObject);  
        }
    }
}
