using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = newVelocity;
    }

}
