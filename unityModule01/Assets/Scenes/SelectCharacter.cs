using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public GameObject[] characters; // Référence aux GameObjects des personnages
    private int activeCharacterIndex = -1; // Index du personnage actif
    private void Start()
    {
        SetDesactivateCharacter();
    }


    private void Update()
    {
        // Change la position de la caméra pour suivre le personnage sélectionné
        if (activeCharacterIndex != -1)
            transform.position = characters[activeCharacterIndex].transform.position - new Vector3(0, 0, 10);
        // Ici, on utilise les touches 1, 2 et 3 pour changer de personnage (0, 1 et 2 dans le tableau)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCharacter(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCharacter(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeCharacter(2);
        }
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fonction pour changer de personnage
    private void ChangeCharacter(int index)
    {
        if (index < characters.Length && index != activeCharacterIndex)
        {
            SetDesactivateCharacter();
            activeCharacterIndex = index;
            characters[activeCharacterIndex].GetComponent<PlayerController>().enabled = true;
        }
    }

    private void SetDesactivateCharacter()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].GetComponent<PlayerController>().enabled = false;
        }
    }
}
