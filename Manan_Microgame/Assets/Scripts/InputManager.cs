/* 
This class is reponsible for managing all the inputs (Movement, MouseLook and Gun(Shoot)).

The Awake function initializes control and initializes every other input action. It initializes the input actions
by reading the input values and storing them into variables or running functions. The variables can be used by the respective
input class(Gun, Movement, MouseLook) to 

The OnEnable function enables the controls without this the controls of the game do not work.

The OnDestroy function disables the controls 

The Update function invokes the RecieveInput functions for a Movement and MouseLook object. This function passes horizontal movement
coordinates (x and z axis) and Mouse axis rotations so the respective classes so they can make changes in the game.
*/

using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] Gun gun;
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    private Vector2 horizontalInput;
    private Vector2 mouseInput;
    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Jump.performed += _ => movement.OnJumpPressed();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        groundMovement.Shoot.performed += _ => gun.Shoot();
        AudioListener.volume = 1f;
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    
    private void OnDestroy()
    {
        controls.Disable();
    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }
}
