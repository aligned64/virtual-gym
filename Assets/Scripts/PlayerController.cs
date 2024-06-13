using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public new Camera camera;

    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;

    private bool controlsLocked = false;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (controlsLocked) return;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
    }

    private void FixedUpdate()
    {
        if (controlsLocked) return;

        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = transform.TransformDirection(newVelocity);
    }

    private void LateUpdate()
    {
        if (controlsLocked) return;

        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        e.x = RestrictAngle(e.x, -85f, 85f);
        head.eulerAngles = e;
    }

    private float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }
    public void LockControls()
    {
        controlsLocked = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void UnlockControls()
    {
        controlsLocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

