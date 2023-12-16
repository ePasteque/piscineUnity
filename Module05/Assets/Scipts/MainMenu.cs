using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Button resumeButton;
    private Button NewGameButton;
    private Button DiaryButton;

    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        resumeButton = root.rootVisualElement.Q<Button>("Resume");
        resumeButton.RegisterCallback<ClickEvent>(ResumeGame);
        NewGameButton = root.rootVisualElement.Q<Button>("NewGame");
        NewGameButton.RegisterCallback<ClickEvent>(NewGame);
        DiaryButton = root.rootVisualElement.Q<Button>("Diary");
        DiaryButton.RegisterCallback<ClickEvent>(Diary);
    }

    void OnDisable()
    {
        resumeButton.UnregisterCallback<ClickEvent>(ResumeGame);
        NewGameButton.UnregisterCallback<ClickEvent>(NewGame);
        DiaryButton.UnregisterCallback<ClickEvent>(Diary);
    }

    void ResumeGame(ClickEvent evt)
    {
        GameManager.ResumeGame();
        Debug.Log("Resume");
    }

    void NewGame(ClickEvent evt)
    {
        GameManager.NewGame();
        Debug.Log("New Game");
    }

    void Diary(ClickEvent evt)
    {
        Debug.Log("Diary");
        SceneManager.LoadScene("Diary");
    }
}
