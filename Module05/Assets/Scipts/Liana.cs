using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liana : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            animator.SetTrigger("Attack");
            audioSource.Play();
        }
    }
}
