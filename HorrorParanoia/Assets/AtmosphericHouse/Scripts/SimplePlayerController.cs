using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SimplePlayerController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 1.15f;
    public float runSpeed = 4.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public float gravity = 150.0f;
    public Vector3 currentPosition;
    public Quaternion currentRotation;
    public bool inTransition;
    public float time;
    public Vector3 targetPosition;
    public Quaternion targetRotation;
    public Quaternion playerCameraRotation;
    [SerializeField] public GameObject currentDoor;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    public float rotationX = 0;
    private bool canMove = true;
    private AudioSource audioSource;
    [SerializeField] private AudioClip footStep;
    private float currentSpeed;
    private bool startDelay;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        //float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float curSpeedX = Input.GetAxisRaw("Vertical");
        float curSpeedY = Input.GetAxisRaw("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX + right * curSpeedY);
        moveDirection = moveDirection.normalized;

        SetSpeed();
        PlayFootSteps();

        if (inTransition)
        {
            characterController.enabled = false;
            PassingThroughDoors(currentPosition, targetPosition);
        }
        else
        {
            startDelay = false;
            characterController.enabled = true;
        }

        if(characterController.enabled)
        {
            if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
            {
                characterController.Move(Vector3.zero);
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            else
            {
                moveDirection.y = 0;
            }

            characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }
    }

    IEnumerator EnablePlayerMovement()
    {
        yield return new WaitForSeconds(1.5f);
        SetTransitState(false);
    }

    public void SetSpeed()
    {
        currentSpeed = canMove ? (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed) : 0;
    }
    
    public void SetTransitState(bool bo)
    {
        inTransition = bo;
    }

    public void GetCurrentPosition()
    {
        currentPosition = transform.position;
        currentRotation = transform.rotation;
        playerCameraRotation = playerCamera.transform.localRotation;
    }

    public void PassingThroughDoors(Vector3 currentPosition, Vector3 targetPosition)
    {
        if (time >= 1.2f && !startDelay)
        {
            rotationX = 0;
            startDelay = true;
            StartCoroutine(EnablePlayerMovement());
            currentDoor.BroadcastMessage("ObjectClicked");
            currentDoor.BroadcastMessage("PlaySFX");
        }
        transform.position = Vector3.Lerp(currentPosition, targetPosition, time);
        playerCamera.transform.localRotation = Quaternion.Lerp(playerCameraRotation, Quaternion.Euler(0,0,0), time);
        transform.rotation = Quaternion.Lerp(currentRotation,targetRotation, time);
        time += Time.deltaTime / 2.5f;
    }

    public void SetCurrentDoor(GameObject GO)
    {
        currentDoor = GO;
    }

    public void SetDestination(Transform destination)
    {
        time = 0;
        targetPosition = destination.position;
        targetPosition.y = transform.position.y;
        targetRotation = destination.rotation;
    }

    private void PlayFootSteps()
    {
        var velocity = characterController.velocity;
        velocity.y = 0;
        if(velocity != Vector3.zero && !audioSource.isPlaying && !inTransition)
        {
            audioSource.PlayOneShot(footStep);
        }
        else if(characterController.velocity == Vector3.zero || inTransition)
        {
            audioSource.Stop();
        }
    }

    public void StopAllSounds()
    {
        audioSource.Stop();
    }
}