using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMover : MonoBehaviour
{
    public float power = 10000f;
    public float rotate = 1f;
    public Rigidbody rb;
    public AudioClip startClip;
    public AudioClip runClip;
    public AudioSource engineSource;
    public AudioSource sfxSource;
    float force;
    float lastForce;
    private void FixedUpdate()
    {
        var angularVelocity = rb.angularVelocity;
        angularVelocity.x = 0; // 앞뒤로 흔들리는 물리 제거
        angularVelocity.z = 0; // 좌우로 흔들리는 물리 제거
        rb.angularVelocity = angularVelocity;

        float forwardMove = Input.GetAxis("Vertical");
        force = forwardMove * power;
        if (force != 0)
        {
            PlayFirstStartSound();
            var velocity = rb.velocity;
            velocity.x = 0;
            velocity.z = 0;
            rb.velocity = velocity;
            var forward = transform.forward;
            forward.y = 0;
            rb.AddForce(forward * force);
        }
        engineSource.volume = forwardMove;

        float rotate = Input.GetAxis("Horizontal") * this.rotate;
        rb.AddRelativeTorque(0, rotate, 0, ForceMode.VelocityChange);
        lastForce = force;
    }

    private void PlayFirstStartSound()
    {
        if (lastForce != 0)
            return;
        sfxSource.Stop();
        sfxSource.clip = startClip;
        sfxSource.Play();
    }

    public void OnStart()
    {
        enabled = true;
        engineSource.clip = runClip;
        engineSource.Play();
    }
}
