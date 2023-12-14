using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.InputSystem.Controls;
// using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    private Rigidbody body;
    public float verticalSpeed = 5; // Ajout de la vitesse verticale pour simuler la gravité
    public float speed = 5f;
    // private readonly float gravity = -9.81f;
    private float size;
    public string[] LayerMaskName;
    private int ignoreLayer;

    void Awake() {
        body = gameObject.AddComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotationZ;
        body.freezeRotation = true;
        //permet d'avoir le millieu du perso
        size = gameObject.GetComponent<Renderer>().bounds.size.x;
        Vector3 hafl_size = new Vector3(size / 2, 0f, 0f);
        ignoreLayer = ~LayerMask.GetMask(LayerMaskName);
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        Vector3 move = new(Input.GetAxis("Horizontal"), 0f, 0f);
        Vector3 hafl_size = new Vector3(size / 2, 0f, 0f);
        body.MovePosition(move * speed * Time.deltaTime + body.position);
        if (Input.GetKeyDown(KeyCode.Space) && (Physics.Raycast(transform.position, Vector3.down, body.GetComponent<Collider>().bounds.extents.y + 0.1f, ignoreLayer) == true 
            || Physics.Raycast(transform.position + hafl_size, Vector3.down, body.GetComponent<Collider>().bounds.extents.y + 0.1f, ignoreLayer) == true 
            || Physics.Raycast(transform.position - hafl_size, Vector3.down, body.GetComponent<Collider>().bounds.extents.y + 0.1f, ignoreLayer) == true)) {
            body.AddForce(new Vector3(0f, verticalSpeed, 0f), ForceMode.Acceleration);
        }
    }
}
