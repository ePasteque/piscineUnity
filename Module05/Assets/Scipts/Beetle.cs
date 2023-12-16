using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Beetle : MonoBehaviour
{
    private bool seeMsg = false;
    GameObject msgBox;
    private float timer = 0f;
    private float timeMax = 2f;

    void Awake()
    {
        msgBox = GameObject.Find("Message");
        msgBox.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (seeMsg)
        {
            msgBox.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= timeMax)
            {
                msgBox.SetActive(false);
                timer = 0f;
                seeMsg = false;
            }
        }        
    }
        void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (GameManager.nb_leaf >= 5)
            {
                GameManager.nextStage();
            }
            else
                seeMsg = true;

        }
    }
}
