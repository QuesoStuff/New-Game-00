
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sound : SOUND
{
    [SerializeField] internal _Player_Script mainScript;
    [SerializeField] internal AudioClip[] soundtrack;
    [SerializeField] internal AudioSource playAudio;

    public new void setComponent()
    {
        mainScript = GetComponent<_Player_Script>();
        //audio = GetComponent<AudioSource>();
    }
    public new void set()
    {
        base.set();
        setComponent();
    }
    public void Start()
    {
        set();
    }
    public void audioShoot_0()
    {
        GetComponent<AudioSource>().clip = audio_array[0];
        GetComponent<AudioSource>().Play();
    }
    public void audioShoot_1()
    {
        GetComponent<AudioSource>().clip = audio_array[1];
        GetComponent<AudioSource>().Play();
    }
    public void audioShoot_charged()
    {
        GetComponent<AudioSource>().clip = audio_array[2];
        GetComponent<AudioSource>().Play();
    }
    public void audioTeleport()
    {
        GetComponent<AudioSource>().clip = audio_array[3];
        GetComponent<AudioSource>().Play();
    }
    public void audioCollision()
    {
        GetComponent<AudioSource>().clip = audio_array[4];
        GetComponent<AudioSource>().Play();
    }
    public void audioDash()
    {
        GetComponent<AudioSource>().clip = audio_array[5];
        GetComponent<AudioSource>().Play();
    }
    public void audioHurt()
    {
        GetComponent<AudioSource>().clip = audio_array[6];
        GetComponent<AudioSource>().Play();
    }
}