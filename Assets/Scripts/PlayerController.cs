using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 9.0f; // Speed of player

    public float jumpHeight = 7.0f; // Height of Jump

    public float playerDown = 5.0f; // height of player down

    public float currentJumpheight = 0f; //Current jump height

    public float runSpeed = 7.0f; // Speed of running;

    public float slowlyMove = 3.0f; // Slowly move

    public float sensitivityMouse = 3.0f; // sensitivity of mouse
    public float mouseUpDown = 0.0f; // variable which remeber move of mouse
    public float mouseScope = 90.0f; // sope of mouse move

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        keyboardController();
        mouseController();
    }

    private void keyboardController()
    {
        float moveVertical = Input.GetAxis("Vertical") * speed; // Speed of walk in vertical

        float moveHorizontal = Input.GetAxis("Horizontal") * speed; // Speed of walk in horizontal

        if(controller.isGrounded && Input.GetButton("Jump")) // Jump controll
        {
            currentJumpheight = jumpHeight;
        }
        else if(!controller.isGrounded)
        {
            currentJumpheight += Physics.gravity.y * Time.deltaTime;
        }

        if(Input.GetKeyDown("left shift")) // Running control - if left shift pressed then run if not walk
        {
            speed += runSpeed;
        }
        else if(Input.GetKeyUp("left shift"))
        {
            speed -= runSpeed;
        }

        if(Input.GetKeyDown("left ctrl"))
        {
            speed -= slowlyMove;
            //currentJumpheight = currentJumpheight - playerDown; 
        }
        else if(Input.GetKeyUp("left ctrl"))
        {
            speed += slowlyMove;
            //currentJumpheight = currentJumpheight + playerDown;
            //Camera.main.transform.localPosition = Quaternion.
        }

        Vector3 move = new Vector3(moveHorizontal, currentJumpheight, moveVertical);// Vector3 is a move vector

        move = transform.rotation * move; 

        controller.Move(move * Time.deltaTime);
    }

    private void mouseController()
    {
        float mouseLeftRight = Input.GetAxis("Mouse X") * sensitivityMouse; //Value of mouse move - if value is positive then turn right else left 
        transform.Rotate(0, mouseLeftRight, 0);

        mouseUpDown -= Input.GetAxis("Mouse Y") * sensitivityMouse; //Value of maous move (up and down) - if vaule positive then up, if negative then down
        mouseUpDown = Mathf.Clamp(mouseUpDown, -mouseScope, mouseScope); // Mathf.Clamp is a function which block value of looking up and down

        Camera.main.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0); // CharacterController doesn`t move up/down so we move only camera

    }
    
}
