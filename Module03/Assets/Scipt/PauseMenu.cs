using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject confirmQuit;
    void Awake()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        confirmQuit = GameObject.Find("ConfirmQuit");
    }
    // Start is called before the first frame update
    void Start()    
    {
        pauseMenu.SetActive(false);
        confirmQuit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            Debug.Log("Pause"); 
        }
    }
}
