using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDemo : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public new Camera camera;

    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;



    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
        
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = transform.TransformDirection(newVelocity);
    }

    private void LateUpdate()
    {
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
}
