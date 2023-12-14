using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject[] players;
    private Collider[] hitColliders;
    public Vector3 vector3;

    void OnTriggerStay(Collider other)
    {
        hitColliders = Physics.OverlapBox(vector3, other.gameObject.GetComponent<Collider>().bounds.size / 2f);
        if (hitColliders.Length == 0)
        {
            other.gameObject.transform.position = vector3;
        }
    }   
}
