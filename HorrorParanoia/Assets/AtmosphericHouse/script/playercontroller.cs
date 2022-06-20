using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField] Transform playercamera = null;
    [SerializeField] float mousesensitivity = 3.5f;
    [SerializeField] bool cursordisspear = true;
    [SerializeField] float walkspeed = 6.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float movesmoother = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mousesmoother = 0.03f;
    [SerializeField] float gravity = -13.0f;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;
    Vector2 currentdir = Vector2.zero;
    Vector2 currentdirv = Vector2.zero;
    Vector2 currentmousedelta = Vector2.zero;
    Vector2 currentmousedeltav = Vector2.zero;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (cursordisspear)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        updatemovement();
    }
    void UpdateMouseLook()
    {
        Vector2 targetmouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentmousedelta = Vector2.SmoothDamp(currentmousedelta, targetmouseDelta, ref currentmousedeltav, mousesmoother);

        cameraPitch -= currentmousedelta.y * mousesensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        playercamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentmousedelta.x * mousesensitivity);
    }
    void updatemovement()
    {
        Vector2 tragetdir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        tragetdir.Normalize();
        currentdir = Vector2.SmoothDamp(currentdir, tragetdir, ref currentdirv, movesmoother);
        Vector3 velocity = (transform.forward * currentdir.y + transform.right * currentdir.x) * walkspeed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
        if (controller.isGrounded)
            velocityY = 0.0f;
        velocityY += gravity * Time.deltaTime;
    }
}
