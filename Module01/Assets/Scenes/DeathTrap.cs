using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{
    public GameObject cam;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Game Over !");
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            cam.GetComponent<CameraController>().enabled = false;
        }
    }
}
