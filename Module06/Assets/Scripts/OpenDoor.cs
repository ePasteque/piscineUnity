using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private bool isOpen = false;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOpen)
            {
                animator.SetTrigger("Open");
                isOpen = true;
            }
        }
    }
}
