using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{

    public Base myBase;
    private int energy;
    private VisualElement fastTouret;
    private VisualElement slowTouret;
    private VisualElement mediumTouret;
    public GameObject fastTouretPrefab;
    public GameObject slowTouretPrefab;
    public GameObject mediumTouretPrefab;
    private GameObject actualTouret;

    public Tilemap isTouret;
    public Tile transparentTile;
    private bool onDrag = false;

    void OnEnable() {
        UIDocument root = GetComponent<UIDocument>();
        root.rootVisualElement.RegisterCallback<PointerUpEvent>(DropTouret);
        fastTouret = root.rootVisualElement.Q<VisualElement>("FastTouret");
        fastTouret.RegisterCallback<PointerDownEvent>(FastTouret);
        slowTouret = root.rootVisualElement.Q<VisualElement>("SlowTouret");
        slowTouret.RegisterCallback<PointerDownEvent>(SlowTouret);
        mediumTouret = root.rootVisualElement.Q<VisualElement>("MediumTouret");
        mediumTouret.RegisterCallback<PointerDownEvent>(MediumTouret);
    }

    void Start() {
        onDrag = false;
    } 

    void DropTouret(PointerUpEvent evt) {
        onDrag = false;
        Debug.Log("DropTouret");
        if (actualTouret != null) {
            Tilemap tilemapSpot = GameObject.Find("TouretSpot").GetComponent<Tilemap>();
            Tilemap tilemapIsTouret = GameObject.Find("isTouret").GetComponent<Tilemap>();
            Vector3Int cellPosition = tilemapSpot.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (tilemapSpot.GetTile(cellPosition) != null && tilemapIsTouret.GetTile(cellPosition) == null) {
                tilemapIsTouret.SetTile(cellPosition, transparentTile);
                // actualTouret.transform.position = tilemapSpot.GetCellCenterWorld(cellPosition);
                GameObject newTouret = Instantiate(actualTouret);
                newTouret.GetComponent<Tourets>().isDrag = false;
                newTouret.transform.position = tilemapSpot.GetCellCenterWorld(cellPosition);
                // actualTouret = null;
                Destroy(actualTouret);
            }
            else {
                Debug.Log("Destroy"); 
                Destroy(actualTouret);
            }
        }
    }
    void FastTouret(PointerDownEvent evt) {
        if (energy >= 5) {
            onDrag = true;
            Debug.Log("FastTouret");
            actualTouret = Instantiate(fastTouretPrefab);
        }
    }

    void SlowTouret(PointerDownEvent evt) {
        if (energy >= 1) {
            onDrag = true;
            Debug.Log("SlowTouret");
            actualTouret = Instantiate(slowTouretPrefab);
            GameObject.Find("actualTouret").SetActive(false);
        }
    }

    void MediumTouret(PointerDownEvent evt) {
        if (energy >= 3) {
            onDrag = true;
            Debug.Log("MediumTouret");
            actualTouret = Instantiate(mediumTouretPrefab);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (onDrag == true && actualTouret != null) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            actualTouret.transform.position = mousePos;
        }
        energy = myBase.energy;
        if (energy < 1) {
            slowTouret.style.unityBackgroundImageTintColor = Color.red;
        }
        else {
            slowTouret.style.unityBackgroundImageTintColor = Color.white;
        }
        if (energy < 3) {
            mediumTouret.style.unityBackgroundImageTintColor = Color.red;
        }
        else {
            mediumTouret.style.unityBackgroundImageTintColor = Color.white;
        }
        if (energy < 5) {
            fastTouret.style.unityBackgroundImageTintColor = Color.red;
        }
        else {
            fastTouret.style.unityBackgroundImageTintColor = Color.white;
        }        
    }

    
}
