using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class John : MonoBehaviour
{
    private float vitesseRotation = 100.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource stepAudio;

    void Update()
    {
        if (GameManager.getCaugth == true)
        {
            animator.SetFloat("MovingSpeed", 0);
            return;
        }
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("MovingSpeed", vertical);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            stepAudio.Play();
        } else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            stepAudio.Stop();
        }
        transform.Rotate(Vector3.up, horizontal * vitesseRotation * Time.deltaTime);
        gameObject.GetComponent<CharacterController>().Move(Vector3.down);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            Debug.Log("Game Over");
            GameManager.getCaugth = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().endGame(false);
            GameManager.isGameOver = true;
        }
        if (other.CompareTag("Exit"))
        {
            Debug.Log("Win");
            GameManager.getCaugth = true;            
            GameObject.Find("GameManager").GetComponent<GameManager>().endGame(true);
        }
    }
}
