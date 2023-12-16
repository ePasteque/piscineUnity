using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GoToMenu : MonoBehaviour
{
    private Button menuButton;

    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        menuButton = root.rootVisualElement.Q<Button>("Menu");
        menuButton.RegisterCallback<ClickEvent>(GoToMenuScene);
    }

    void OnDisable()
    {
        menuButton.UnregisterCallback<ClickEvent>(GoToMenuScene);
    }

    void GoToMenuScene(ClickEvent evt)
    {
        GameManager.GoToMenu();
        Debug.Log("Go to Menu");
    }
}
