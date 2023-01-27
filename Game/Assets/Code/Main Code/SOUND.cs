
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUND : MonoBehaviour
{
    [SerializeField] internal AudioClip[] audio_array;
    [SerializeField] internal AudioSource audio_current;

    public void setComponent()
    {
        audio_current = GetComponent<AudioSource>();
    }
    public void set()
    {
        setComponent();
    }
    public void audio_play(int index)
    {
        audio_current.clip = audio_array[index];
        audio_current.Play();
    }
    public void audio_play()
    {
        audio_play(0);
    }
}