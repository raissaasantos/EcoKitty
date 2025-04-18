using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        //Grab references for rigigbody and animator from object
        body = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2 (horizontalInput * speed, body.linearVelocity.y);

        //Flip player when moving right-left
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        }

        //Set animator parameters
        anim.SetBool("running", horizontalInput != 0);
    }
}
