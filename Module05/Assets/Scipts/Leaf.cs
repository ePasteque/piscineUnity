using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    private bool isPickUp = false;
    private float timer = 0f;
    private float timeMax = 0.851f;
    private bool playAnim = false;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickUp)
        {
            if (!playAnim)
            {
                animator.SetTrigger("PickUp");
                playAnim = true;
                GameManager.nb_leaf++;
                GameManager.AddPoints(5);
            }

            timer += Time.deltaTime;
            if(timer >= timeMax)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                // Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isPickUp = true;
        }
    }
}
