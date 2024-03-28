using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private float speed = 3f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
    //receive the inputs for our InputManager.cs and apply them to our character controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        Debug.Log("x : " + input.x + " :  z : " + input.y);

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
   


        moveDirection.x = h * speed;
        moveDirection.z = v* speed;


        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 0;
            

           // playerVelocity.y = 2f;
        controller.Move(playerVelocity * Time.deltaTime);
       // Debug.Log(playerVelocity.y);
    }
    
    public void Jump()
    {
        if (isGrounded) 
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
