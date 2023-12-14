using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 2f;
    public float dmg;
    public Vector3 positionEnemy;
    private float distance;
    public float enemyMoveSpeed;
    private int presicion = 4;
    private Vector3 newPos;
    private Vector3 delta;
    void Start()
    {
        distance = Vector3.Distance(positionEnemy, transform.position);
        float TimeToReachTarget = distance / moveSpeed;
        newPos = new Vector3(positionEnemy.x, positionEnemy.y - TimeToReachTarget * enemyMoveSpeed, positionEnemy.z);
        for (int i = 0; i < presicion; i++)
        {
            distance = Vector3.Distance(newPos, transform.position);
            TimeToReachTarget = distance / moveSpeed;
            newPos = new Vector3(positionEnemy.x, positionEnemy.y - TimeToReachTarget * enemyMoveSpeed, positionEnemy.z);
        }
        delta = (newPos - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Bullet");
        transform.position += delta * moveSpeed * Time.deltaTime;
        // transform.Translate(distance * moveSpeed * Time.deltaTime);
        // transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
    }
}
