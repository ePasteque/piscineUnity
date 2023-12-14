using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuButtons : MonoBehaviour
{
    private Button resumeButton;
    private Button quitButton;
    private GameObject confirmQuit;
    private GameObject pauseMenu;
    private GameObject outsideBounds;

    void Awake()
    {
        confirmQuit = GameObject.Find("ConfirmQuit");
        pauseMenu = GameObject.Find("PauseMenu");
        outsideBounds = GameObject.Find("OutsideBounds");
    }

    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        resumeButton = root.rootVisualElement.Q<Button>("Resume");
        resumeButton.RegisterCallback<ClickEvent>(ResumeGame);
        quitButton = root.rootVisualElement.Q<Button>("Quit");
        quitButton.RegisterCallback<ClickEvent>(QuitGame);
    }

    void OnDisable()
    {
        resumeButton.UnregisterCallback<ClickEvent>(ResumeGame);
        quitButton.UnregisterCallback<ClickEvent>(QuitGame);
    }

    void ResumeGame(ClickEvent evt)
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        outsideBounds.SetActive(true);
    }

    void QuitGame(ClickEvent evt)
    {
        Debug.Log("Quit Confirm");
        // Application.Quit();
        pauseMenu.SetActive(false);
        confirmQuit.SetActive(true);
        outsideBounds.SetActive(false);
    }
}
