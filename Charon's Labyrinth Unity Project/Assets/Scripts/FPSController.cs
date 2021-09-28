using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public float sprintTime;
    public float sprintTimeMax;

    AudioSource audioStepFX;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = false;
    public bool canRun;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioStepFX = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (canMove && sprintTime > 0)
        {
            canRun = true;
        }
        else
        {
            canRun = false;
        }

        if (canMove && canRun && isRunning)
        {
            sprintTime = sprintTime - 1.5f * Time.deltaTime;
        }
        else if (!isRunning && sprintTime < sprintTimeMax)
        {
            sprintTime = sprintTime + 1f * Time.deltaTime;
        }

        

        float curSpeedX = canMove ? (canRun && isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (canRun && isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //--------------------------------------------------------------------

        //StepsSounds
        if (characterController.velocity.magnitude >= 0.85f && audioStepFX.isPlaying == false)
        {
            //isMoving = true;
            audioStepFX.volume = Random.Range(0.8f, 1f);
            audioStepFX.pitch = Random.Range(0.7f, 0.95f);
            audioStepFX.Play();
            //при включение - доиграть до конца
        }
        /*else if (characterController.velocity.magnitude >= 0.85f && audioStepFX.isPlaying == false && isRunning)
        {
            audioStepFX.volume = Random.Range(0.95f, 1.25f);
            audioStepFX.pitch = Random.Range(0.85f, 1.05f);
            audioStepFX.Play();
        }*/
        else if (characterController.velocity.magnitude < 0.85f /*&& audioStepFX.isPlaying*/)
        {
            audioStepFX.Pause();
        }
        


        //StepsSound

        //--------------------------------------------------------------------

        //Jumping
        /*
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        */
        //Jumping

        //--------------------------------------------------------------------

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
