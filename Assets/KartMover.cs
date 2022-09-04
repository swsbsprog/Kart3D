using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMover : MonoBehaviour
{
    public float acc = 10000f;      // 가속도(acceleration)
    public float maxSpeed = 10000f;
    public float currentSpeed = 0;
    public float attenuation = 100;   // 마찰에 의한 속도 감쇠('감쇠'는 '힘이나 세력 따위가 줄어서 약하여짐.')
    [SerializeField] float maxAttenuation;
    public float backSpeedRatio = 0.5f;

    public float rotate = 1f;
    public Rigidbody rb;
    public AudioClip startClip;
    public AudioClip runClip;
    public AudioClip maxRunClip;
    public AudioSource engineSource;
    public AudioSource sfxSource;
    float lastForce;
    private void FixedUpdate()
    {
        var angularVelocity = rb.angularVelocity;
        angularVelocity.x = 0; // 앞뒤로 흔들리는 물리 제거
        angularVelocity.z = 0; // 좌우로 흔들리는 물리 제거
        rb.angularVelocity = angularVelocity;

        float forwardMove = Input.GetAxis("Vertical");
        if (forwardMove > 0)
            PlayFirstStartSound();
         
        currentSpeed = currentSpeed + acc * forwardMove;  // 속도 증가/감소
        float absCurrentSpeed = Math.Abs(currentSpeed);
        maxAttenuation = Math.Clamp(acc * attenuation, -absCurrentSpeed, absCurrentSpeed);
        currentSpeed = currentSpeed + (currentSpeed > 0 ? -maxAttenuation : maxAttenuation); // 감쇠
        currentSpeed = Math.Clamp(currentSpeed, - maxSpeed * backSpeedRatio, maxSpeed);
        float force = currentSpeed;
        
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

        engineSource.volume = Math.Abs(currentSpeed) / maxSpeed;
        var lastClip = engineSource.clip;
        engineSource.clip = currentSpeed == maxSpeed ? maxRunClip : runClip;
        if(lastClip != engineSource.clip)
            engineSource.Play();

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
}
