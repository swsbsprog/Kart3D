using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void ChangeMasterVolume(float value) => ChangeVolume("Master", value);
    public void ChangeBGMVolume(float value) => ChangeVolume("BGM", value);
    public void ChangeSFXVolume(float value) => ChangeVolume("SFX", value);

    private void ChangeVolume(string groupName, float value)
    {
        audioMixer.SetFloat(groupName, value);
    }
}
