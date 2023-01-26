
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUND : MonoBehaviour
{
    // if you do decide on producing children with this class
    [SerializeField] internal AudioClip[] audio_array;
    [SerializeField] internal AudioSource audio;

    public void setComponent()
    {
       // audio = GetComponent<AudioSource>();
    }
    public void set()
    {
        setComponent();
    }
    public void audio_play(int index)
    {
        audio.clip = audio_array[index];
        audio.Play();
    }
}