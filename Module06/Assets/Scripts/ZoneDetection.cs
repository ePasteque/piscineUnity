using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.isSpoted = true;
        }
    }
}
