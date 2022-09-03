using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startClip;
    private void Update()
    {
        if(StageManager.instance.isGameStart == false)
        {
            if(Input.GetAxis("Vertical") > 0)
            {
                audioSource.Stop();
                audioSource.clip = startClip;
                audioSource.Play();
            }
        }
    }
}
