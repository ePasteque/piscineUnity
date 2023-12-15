using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject SpitPrefab;
    [SerializeField] private GameObject SpitSpawn;
    [SerializeField] private AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        audioSource.Play();
        Instantiate(SpitPrefab, SpitSpawn.transform.position, transform.rotation);
    }
}
