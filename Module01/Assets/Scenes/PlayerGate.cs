using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGate : MonoBehaviour
{
    public GameObject[] players;
    public float tolerance = 0.1f;
    private bool[] gate = {false, false, false};
    private int onGate = 0;
    public string nextSceneName;

    void Start()
    {
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
    void OnTriggerStay(Collider other)
    {
        Transform child;
        string gateName = other.name + "'s Gate";
        for (int i = 0; i < players.Length; i++)
        {
            child = transform.GetChild(i);
            if (gateName == child.name)
            {
                LineRenderer line = child.GetComponent<LineRenderer>();
                Vector3 gateCenter = new Vector3(child.position.x + line.GetPosition(2).x / 2f, child.position.y + line.GetPosition(2).y / 2f, child.position.z);
                if (gateCenter.x - tolerance <= other.transform.position.x && other.transform.position.x <= gateCenter.x + tolerance)
                {
                    if (gateCenter.y - tolerance <= other.transform.position.y && other.transform.position.y <= gateCenter.y + tolerance && gate[i] == false)
                    {
                        Debug.Log("Player " + other.name + " is in the gate");
                        gate[i] = true;
                        onGate++;
                    }
                }
                if (!(gateCenter.x - tolerance <= other.transform.position.x && other.transform.position.x <= gateCenter.x + tolerance))
                {
                    if (gate[i] == true) {
                        Debug.Log("Player " + other.name + " leave the gate");
                        gate[i] = false;
                        onGate--;
                    }
                }
                // Debug.Log(other.transform.position + " " + gateCenter);
            }
            if (onGate == players.Length)
            {
                Debug.Log("You win !");
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}

