using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeathandEnergy : MonoBehaviour
{
    private ProgressBar healthBar;
    private ProgressBar energyBar;

    public Base MyBase;
    void OnEnable()
    {
        UIDocument root = GetComponent<UIDocument>();
        healthBar = root.rootVisualElement.Q<ProgressBar>("HealthBar");
        energyBar = root.rootVisualElement.Q<ProgressBar>("EnergyBar");
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = MyBase.health;
        energyBar.value = MyBase.energy;
    }
}
