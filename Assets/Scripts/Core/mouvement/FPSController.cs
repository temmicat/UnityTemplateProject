using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastTrain.Core
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSController : MonoBehaviour
    {
       
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float crouchSpeed = 1f;
    
    public bool isCrouching;

    public Transform cameraHolderTransform;
    private Vector3 normalHeight;
 
 
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
 
 
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
 
    public bool canMove = true;
 
    
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        normalHeight = cameraHolderTransform.position;
    }
 
    void Update()
    {
 
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
 
        // Press Left Shift to run
        // bool isRunning = Input.GetKey(KeyCode.LeftShift);
        
        // Press Left Control to Crouch
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        
        float curSpeedX = canMove ? (isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = 9.81f;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY) + Vector3.down * movementDirectionY;
 
        
        if (isCrouching)
        {
            var position = cameraHolderTransform.position;
            playerCamera.transform.position = new Vector3(position.x, 
                position.y - 1f,
                position.z);
        }
        else
        {
            playerCamera.transform.position = cameraHolderTransform.position;
        }
        
        characterController.Move(moveDirection * Time.deltaTime);
 
        #endregion
        
        #region Handles Rotation
 
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
 
        #endregion
    }
    }
}
