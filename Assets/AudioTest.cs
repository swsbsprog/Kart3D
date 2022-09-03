using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audioSource.clip = clip[0];
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioSource.clip = clip[1];
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audioSource.clip = clip[2];
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            audioSource.clip = clip[3];
            audioSource.Play();
        }
    }
}
