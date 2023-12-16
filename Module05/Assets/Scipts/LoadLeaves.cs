using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLeaves : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.isNewGame)
            return;
        GameObject[] leaves = GameObject.FindGameObjectsWithTag("Collectible");
        for (int i = 0; i < leaves.Length; i++)
        {
            GameObject temp = null;
            string name = PlayerPrefs.GetString("leaf" + i);
            for (int j = 0; j < leaves.Length; j++)
            {
                if (leaves[j].name == name)
                {
                    temp = leaves[j];
                    break;
                }
            }
            if (temp && PlayerPrefs.GetInt("isTaken" + i) == 1)
            {
                temp.GetComponent<SpriteRenderer>().enabled = false;
                temp.GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (temp)
            {
                temp.GetComponent<SpriteRenderer>().enabled = true;
                temp.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
