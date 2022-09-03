using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    public float power = 10000f;
    public float rotate = 1f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var angularVelocity = rb.angularVelocity;
        angularVelocity.x = 0; // 앞뒤로 흔들리는 물리 제거
        angularVelocity.z = 0; // 좌우로 흔들리는 물리 제거
        rb.angularVelocity = angularVelocity; 

        float force = Input.GetAxis("Vertical") * power ;
        if (force != 0)
        {
            var velocity = rb.velocity;
            velocity.x = 0;
            velocity.z = 0;
            rb.velocity = velocity;
            var forward = transform.forward;
            forward.y = 0;
            rb.AddForce(forward * force);
        }

        float rotate = Input.GetAxis("Horizontal") * this.rotate;
        transform.Rotate(0, rotate, 0, Space.Self);
    }
}
