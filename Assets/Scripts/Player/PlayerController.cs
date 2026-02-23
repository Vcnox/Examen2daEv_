using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 15f; 
    public float gravityForce = 0.11f; 
    public float playerJump = 0.03f;
    public float yVelocity = 0f;

    private CharacterController characterController;





    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 
        float y = Input.GetAxis("Jump");

        Vector3 movement = transform.right * x + transform.forward * z;

        movement *= playerSpeed;

        if(Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            yVelocity = 0;
            yVelocity += playerJump;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 30f;
        }
        else
        {
            playerSpeed = 15f;
        }

        yVelocity -= gravityForce * Time.deltaTime;
        movement *= Time.deltaTime;
        movement.y = yVelocity;

        characterController.Move(movement);



    }
}
