using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Button playButton;
    private Button quitButton;
    public string sceneName;
    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        playButton = root.rootVisualElement.Q<Button>("Play");
        playButton.RegisterCallback<ClickEvent>(PlayGame);
        quitButton = root.rootVisualElement.Q<Button>("Exit");
        quitButton.RegisterCallback<ClickEvent>(QuitGame);

    }

    void OnDisable()
    {
        playButton.UnregisterCallback<ClickEvent>(PlayGame);
        quitButton.UnregisterCallback<ClickEvent>(QuitGame);
    }

    void PlayGame(ClickEvent evt)
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene(sceneName);
    }

    void QuitGame(ClickEvent evt)
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
