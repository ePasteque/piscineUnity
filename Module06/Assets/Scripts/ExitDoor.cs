using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    private bool isOpen = false;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(GameManager.nb_keys);
            if (GameManager.nb_keys >= 3 && !isOpen)
            {
                animator.SetTrigger("Open");
                isOpen = true;
            }
        }
    }
}
