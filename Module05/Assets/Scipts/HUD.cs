using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    private Label hp;
    private Label score;
    // Start is called before the first frame update

    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        hp = root.rootVisualElement.Q<Label>("HP");
        score = root.rootVisualElement.Q<Label>("Score");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "HP: " + GameManager.health;
        score.text = "Score: " + GameManager.ttPoints;
    }
}
