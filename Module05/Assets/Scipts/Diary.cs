using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Diary : MonoBehaviour
{
    private Label death;
    private Label score;
    private Button homeButton;
    private string stage;
    private VisualElement stage1;
    private VisualElement stage2;
    private VisualElement stage3;


    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        death = root.rootVisualElement.Q<Label>("Death");
        score = root.rootVisualElement.Q<Label>("Score");
        homeButton = root.rootVisualElement.Q<Button>("Home");
        homeButton.RegisterCallback<ClickEvent>(Home);
        stage1 = root.rootVisualElement.Q<VisualElement>("stage1");
        stage2 = root.rootVisualElement.Q<VisualElement>("stage2");
        stage3 = root.rootVisualElement.Q<VisualElement>("stage3");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Home(ClickEvent evt)
    {
        Debug.Log("Home");
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        death.text = PlayerPrefs.GetInt("death").ToString();
        score.text = PlayerPrefs.GetInt("ttPoints").ToString();
        stage = PlayerPrefs.GetString("stage");
        if (stage == "Stage1") {
            stage2.style.unityBackgroundImageTintColor = new Color(0, 0, 0, 0);
            stage3.style.unityBackgroundImageTintColor = new Color(0, 0, 0, 0);
        } else if (stage == "Stage2") {
            stage3.style.unityBackgroundImageTintColor = new Color(0, 0, 0, 0);
        }        
    }
}
