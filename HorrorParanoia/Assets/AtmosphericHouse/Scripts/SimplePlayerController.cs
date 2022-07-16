﻿using System.Collections;
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
        float curSpeedX = Input.GetAxis("Vertical");
        float curSpeedY = Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX + right * curSpeedY);
        moveDirection = moveDirection.normalized;

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            characterController.Move(Vector3.zero);
        }

        SetSpeed();
        PlayFootSteps();

        if (inTransition)
        {
            characterController.enabled = false;
            PassingThroughDoors(currentPosition, targetPosition);
        }
        else
        {
            characterController.enabled = true;
        }

        if(characterController.enabled)
        {
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

    public void SetSpeed()
    {
        currentSpeed = canMove ? (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed) : 0;
    }
    
    public void IsTransitioning()
    {
        inTransition = true;
    }

    public void GetCurrentPosition()
    {
        currentPosition = transform.position;
        currentRotation = transform.rotation;
        playerCameraRotation = playerCamera.transform.localRotation;
    }

    public void PassingThroughDoors(Vector3 currentPosition, Vector3 targetPosition)
    {
        if (time >= 1.2f)
        {
            rotationX = 0;
            inTransition = false;
            currentDoor.BroadcastMessage("ObjectClicked");
        }
        transform.position = Vector3.Lerp(currentPosition, targetPosition, time);
        playerCamera.transform.localRotation = Quaternion.Lerp(playerCameraRotation, Quaternion.Euler(0,0,0), time);
        transform.rotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(0, 180, 0), time);
        time += Time.deltaTime / 1.2f;
    }

    public void SetCurrentDoor(GameObject GO)
    {
        currentDoor = GO;
    }

    public void SetDestination(Vector3 destination)
    {
        time = 0;
        targetPosition = destination;
        targetPosition.y = transform.position.y;
    }

    private void PlayFootSteps()
    {
        if(characterController.velocity != Vector3.zero && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footStep);
        }
        else if(characterController.velocity == Vector3.zero)
        {
            audioSource.Stop();
        }
    }
}