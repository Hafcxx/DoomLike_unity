using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D theRB;
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        theRB.velocity = moveInput * moveSpeed; 
    }
}
