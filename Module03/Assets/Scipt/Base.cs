using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int health = 5;
    public int energy = 0;
    public int maxEnergy = 15;

    private float timer = 0f;
    private float incrementInterval = 1f; // Intervalle d'incrémentation en secondes

    void Start()
    {
        health = 5;
    }
    void Update()
    {
        timer += Time.deltaTime; // Incrémente le compteur de temps

        if (timer >= incrementInterval)
        {
            energy++;
            timer = 0f; // Réinitialise le compteur
        }
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
