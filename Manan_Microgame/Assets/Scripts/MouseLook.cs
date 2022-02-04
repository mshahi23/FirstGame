/* 
This class is reponsible for the first person camera movement.

The ReceiveInput function is invoked by the InputManger and it receives a Vector2 which contains the axis for
X axis rotation of the camera and the y axis rotation of the camera. This is used to initialize the values of 
mouseX and mouseY, the axis value are multiplied by the sensitivity for the corresponding axis.

The Start functions makes sures that the mouse cursor is locked to center and is not visible while playing the
game. This is crucial for FPS games. This is done when the scene is loaded.

The Update function makes sures to update the first person camera every frame. deltaTime is used to make sure
the update are consistent even when the frame rate is not. It also applies clamps to the rotation about the x
axis of the camera because we do no want the camera to go into the player and make it appear as if they have 
broken their back.
*/

using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    private float mouseX, mouseY;
    private float xRotation = 0;
    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }
}
