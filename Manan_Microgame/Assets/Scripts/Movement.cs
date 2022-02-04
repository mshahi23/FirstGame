/* 
This class deals with player movement like jumping and running.

The function ReeiveInput is invoked by the InputManager script and it passes a Vector2 input the gives us a
players horizontal input (x and z axis).

The Update function updates the players movement every frame. It transforms the player based on the input. 
deltaTime is used to make sure that player movement is consistent even when the framerate is not. The player can
only jump when they are grounded and cannot repeatedly jump while in the air. Gravity for players that are falling
is also given here.

The OnJumpPressed function is inovked by the input manager and this sets the value of jump to true, allowing the
player to jump again once they are on the ground.
*/

using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] AudioSource jumpEffect;
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3.5f;
    [SerializeField] LayerMask groundMask;
    private Vector2 horizontalInput;
    private bool jump;
    private Vector3 verticalVelocity = Vector3.zero;
    public Transform groundCheck;
    private bool isGrounded;

    public void ReceiveInput (Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        
        if(isGrounded)
        {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * 
        horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);
        

        if(jump)
        {
            if(isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
                jumpEffect.Play();
            }
            
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
    
    public void OnJumpPressed()
    {
        jump = true;
    }
}
