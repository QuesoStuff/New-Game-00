
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUND : MonoBehaviour
{
    // if you do decide on producing children with this class
    [SerializeField] internal AudioClip[] audio_array;
    [SerializeField] internal AudioSource audion_current;

    public void setComponent()
    {
       audion_current = GetComponent<AudioSource>();
    }
    public void set()
    {
        setComponent();
    }
    public void audio_play(int index)
    {
        audion_current.clip = audio_array[index];
        audion_current.Play();
    }
}