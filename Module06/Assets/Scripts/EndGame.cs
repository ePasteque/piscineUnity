using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EndGame : MonoBehaviour
{
    private VisualElement visualElementEnd;

    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        visualElementEnd = root.rootVisualElement.Q<VisualElement>();
    }

    public void end(Texture2D endTexture) {
        visualElementEnd.style.backgroundImage = endTexture;
        gameObject.SetActive(true);
        // visualElementEnd.style.unityBackgroundScaleMode = ScaleMode.ScaleToFit;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
