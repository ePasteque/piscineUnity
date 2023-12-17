using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 spot1;
    [SerializeField] private Vector3 spot2;
    private bool isSpot1 = true;
    private bool PlayerIsSpoted = false;
    private float timer = 0f;
    private float timeMax = 2.5f;

    [SerializeField] private AudioSource ghostAudio;
    void Start()
    {
        agent.SetDestination(spot1);
    }

    void Update()
    {
        if (PlayerIsSpoted == false && agent.remainingDistance < 0.5f)
        {
            if (isSpot1)
            {
                agent.SetDestination(spot2);
                isSpot1 = false;
            }
            else
            {
                agent.SetDestination(spot1);
                isSpot1 = true;
            }
        } else if (PlayerIsSpoted == true || GameManager.isSpoted == true)
        {
            agent.SetDestination(GameObject.Find("JohnLemon").transform.position);
            timer += Time.deltaTime;
            if (timer >= timeMax)
            {
                timer = 0f;
                PlayerIsSpoted = false;
                GameManager.isSpoted = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsSpoted = true;
        }
    }
}
