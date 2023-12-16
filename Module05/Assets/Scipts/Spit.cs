using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    private float horizontal;
    private float speed = 7f;
    private bool touch = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private float timer = 0f;
    private float maxTime = 0.251f;

    void Update()
    {
        if (touch)
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                Destroy(gameObject);
            }   
        }
    }
    private void FixedUpdate()
    {
        if (!touch)
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Player")
        {
            animator.SetTrigger("Touch");
            rb.velocity = Vector2.zero;
            touch = true;

            while (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
