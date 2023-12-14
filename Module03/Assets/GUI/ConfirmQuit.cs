using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConfirmQuit : MonoBehaviour
{
    private Button yesButton;
    private Button noButton;
    private GameObject pauseMenu;
    private GameObject confirmQuit;

    void Awake()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        confirmQuit = GameObject.Find("ConfirmQuit");
        // pauseMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        yesButton = root.rootVisualElement.Q<Button>("Yes");
        yesButton.RegisterCallback<ClickEvent>(Yes);
        noButton = root.rootVisualElement.Q<Button>("No");
        noButton.RegisterCallback<ClickEvent>(No);

    }

    void OnDisable()
    {
        yesButton.UnregisterCallback<ClickEvent>(Yes);
        noButton.UnregisterCallback<ClickEvent>(No);
    }

    void Yes(ClickEvent evt)
    {
        Debug.Log("Yes");
        Application.Quit();
    }

    void No(ClickEvent evt)
    {
        Debug.Log("No");
        pauseMenu.SetActive(true);
        confirmQuit.SetActive(false);
    }
}
