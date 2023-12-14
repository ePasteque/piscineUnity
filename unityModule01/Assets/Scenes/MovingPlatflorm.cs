using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatflorm : MonoBehaviour
{
    public float speed = 1f;
    private bool moveUp = true;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 5.5 && moveUp)
            moveUp = false;
        else if (transform.position.y <= 1.5 && !moveUp)
            moveUp = true;
        if (moveUp)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(12f, 5.5f, 0), speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(12f, 1.5f, 0), speed * Time.deltaTime);
        // Debug.Log(transform.position);
    }
}
