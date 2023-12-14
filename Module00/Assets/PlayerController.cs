using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public float speed = 5f;
//     public float verticalSpeed;
//     public float jump = 3f;
//     private readonly float gravity = -9.81f;
//     private CharacterController controller;
    
//     void Start()
//     {
//         controller = GetComponent<CharacterController>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         verticalSpeed = 0f;
//         // if (Input.GetKey(KeyCode.D))
//         // {
//         //     transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
//         // }

//         // if (Input.GetKey(KeyCode.A))
//         // {
//         //     transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
//         // }

//         // if (Input.GetKey(KeyCode.W))
//         // {
//         //     transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
//         // }

//         // if (Input.GetKey(KeyCode.S))
//         // {
//         //     transform.position -= new Vector3(0f, 0f, speed * Time.deltaTime);
//         // }   

//         // if (controler.isGrounded && Input.GetKey(KeyCode.Space)) {
//         //     verticalSpeed = Mathf.Sqrt(jump * -2f * gravity);
//         // }
//         // if (!controler.isGrounded) {
//         //     transform.position += new Vector3(0f, gravity * Time.deltaTime, 0f);
//         // }
//        if (controller.isGrounded && keyboard.spaceKey.isPressed)
//         {
//             verticalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
//         }

//         Vector3 horizontalMovement = movement * speed;
//         controller.Move(horizontalMovement * Time.deltaTime);

//         // Appliquez la vélocité verticale au CharacterController pour la gravité
//         controller.Move(new Vector3(0, verticalSpeed * 2f, 0) * Time.deltaTime);
//     }
// }

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private float verticalSpeed; // Ajout de la vitesse verticale pour simuler la gravité

    public float speed = 5f;
    private readonly float gravity = -9.81f;
    private readonly float jumpHeight = 0.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        var keyboard = Keyboard.current;

        Vector3 movement = new();

        if (controller.isGrounded) // Si le joueur est au sol
        {
            verticalSpeed = 0f; // Réinitialisez la vitesse verticale lorsque le joueur est au sol

            // Normalisez le vecteur de mouvement pour éviter le mouvement diagonal plus rapide
            if (movement.magnitude > 1f)
            {
                movement.Normalize();
            }
        }
        else
        {
            // Si le joueur n'est pas au sol, appliquez la gravité
            verticalSpeed += gravity * Time.deltaTime;
        }
        
        if (controller.isGrounded && keyboard.spaceKey.isPressed)
        {
            verticalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (keyboard.sKey.isPressed)
        {
            movement += Vector3.right;
        }
        if (keyboard.wKey.isPressed)
        {
            movement += Vector3.left;
        }
        if (keyboard.aKey.isPressed)
        {
            movement += Vector3.back;
        }
        if (keyboard.dKey.isPressed)
        {
            movement += Vector3.forward;
        }


        // Appliquez la vélocité horizontale au CharacterController
        Vector3 horizontalMovement = movement * speed;
        controller.Move(horizontalMovement * Time.deltaTime);

        // Appliquez la vélocité verticale au CharacterController pour la gravité
        controller.Move(new Vector3(0, verticalSpeed * 2f, 0) * Time.deltaTime);
    }
}