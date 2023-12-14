using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
//  private Rigidbody2D body;
//     public float jumpHight = 5; // Ajout de la vitesse verticale pour simuler la gravité
//     public float speed = 5f;
//     // private readonly float gravity = -9.81f;
//     private float size;

//     void Awake() {
//         body = gameObject.GetComponent<Rigidbody2D>();
//         //permet d'avoir le millieu du perso
//         size = gameObject.GetComponent<Renderer>().bounds.size.x;
//         // Vector3 hafl_size = new Vector3(size / 2, 0f, 0f);
//     }

//     void Start()
//     {
//     }

//     void FixedUpdate()
//     {
//         Vector2 move = new(Input.GetAxisRaw("Horizontal"), 0f);
//         // Vector2 hafl_size = new Vector2(size / 2, 0f);
//         body.MovePosition(move * speed * Time.deltaTime + body.position);
//         if (Input.GetKeyDown(KeyCode.Space)/* && (Physics.Raycast(transform.position, Vector3.down, body.GetComponent<Collider>().bounds.extents.y + 0.1f) == true 
//             || Physics.Raycast(transform.position + hafl_size, Vector3.down, body.GetComponent<Collider>().bounds.extents.y + 0.1f) == true 
//             || Physics.Raycast(transform.position - hafl_size, Vector3.down, body.GetComponent<Collider>().bounds.extents.y + 0.1f) == true)*/) {
//             body.AddForce(new Vector3(0f, jumpHight, 0f), ForceMode2D.Impulse);
//         }
//     }

    private float horizontal;
    private float speed = 7f;
    private float jumpingPower = 7f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    void Awake()
    {
        animator.SetInteger("Health", 3);
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (IsGrounded())
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetButtonDown ("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("Jump", true);
            // animator.SetBool("Jump", false);
        }
        Flip();
        animator.SetFloat("MovingSpeed", Mathf.Abs(horizontal));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
   
   private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck. position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
