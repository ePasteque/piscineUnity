using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            health--;
            Debug.Log("Health: " + health);
            if(health <= 0)
            {
                endGame();
            }
        }
    }
    
    void endGame()
    {
        GameObject.Find("Enemy Spawn").SetActive(false);
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
        Debug.Log("Game Over");
    }
}
