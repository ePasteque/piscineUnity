using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 7f;
    private float jumpingPower = 7f;
    private bool isFacingRight = true;
    private int health = 3;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource dmgAudio;
    [SerializeField] private AudioSource spawnAudio;
    [SerializeField] private AudioSource deathAudio;
    [SerializeField] private SpriteRenderer blackOut;
    private bool audioDead = false;
    private float timer = 0f;
    private float timeDeath = 1.485f;
    private float timeSpawn = 0.851f;
    private bool respawn = false;

    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown ("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetTrigger("Jump");
            jumpAudio.Play();
        }
        Flip();
        animator.SetFloat("MovingSpeed", Mathf.Abs(horizontal));
        if (health <= 0)
        {
            DeathAndRespawn();
        }
    }

    void DeathAndRespawn()
    {
        if (!respawn)
        {
            animator.SetBool("IsDead", true);
            animator.SetTrigger("Die");
            if (!audioDead) 
            {
                deathAudio.Play();
                audioDead = true;
                rb.velocity = Vector2.zero; 
            }
            timer += Time.deltaTime;
            blackOut.color = new Color(0, 0, 0, timer / timeDeath);
            if (timer >= timeDeath)
            {
                timer = 0f;
                respawn = true;
            }
        }
        if (respawn)
        {
            audioDead = false;
            transform.position = new Vector3(-6.5f, -3.8f, 0);
            animator.SetBool("IsDead", false);
            spawnAudio.Play();
            timer += Time.deltaTime;
            blackOut.color = new Color(0, 0, 0, 1 - timer / timeSpawn);
            if (timer >= timeSpawn)
            {
                health = 3;
                respawn = false;
                timer = 0f;
                blackOut.color = new Color(0, 0, 0, 0);
            }
        }
    }
    private void FixedUpdate()
    {
        if (!audioDead)
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
   
   private bool IsGrounded()
    {
        Vector2 taille = new Vector2(gameObject.GetComponent<BoxCollider2D>().bounds.size.x- 0.2f, 0.2f);
        return Physics2D.OverlapBox(groundCheck.position, taille,0 , groundLayer);
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("TakeDmg");
            health--;
            if (health > 0)
                dmgAudio.Play();
        }
    }
}
