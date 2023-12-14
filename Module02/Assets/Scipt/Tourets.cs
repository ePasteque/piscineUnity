using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Tourets : MonoBehaviour
{
    public float fireRate;
    public float dmgMultiplier;
    public GameObject bullet;
    public float range = 30f;
    private List<GameObject> enemiesInRange = new List<GameObject>(); // Liste des ennemis dans la zone
    private float fireCountdown = 0f;
    // Start is called before the first frame update
    //dmg output 1 + dmgMultiplier
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy detected");
            GameObject enemy = collision.gameObject;
            enemiesInRange.Add(enemy);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy lost");
            GameObject enemy = collision.gameObject;
            if (enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy); // Supprime l'ennemi de la liste s'il existe toujours
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInRange.Count > 0)
        {
            if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }
            fireCountdown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        //shoot bullet
        GameObject Enemy = enemiesInRange[0];
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.GetComponent<Bullet>().dmg = 1 + dmgMultiplier;        
        bulletClone.GetComponent<Bullet>().positionEnemy = Enemy.transform.position;
        bulletClone.GetComponent<Bullet>().enemyMoveSpeed = Enemy.GetComponent<Enemy>().moveSpeed;
        Debug.Log("Bullet fired");
        // Destroy(bulletClone, 5f);
    }
}
