
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
       audio_play(0);
    }
    public void audioShoot_1()
    {
       audio_play(1);
    }
    public void audioShoot_charged()
    {
       audio_play(2);
    }
    public void audioTeleport()
    {
       audio_play(3);
    }
    public void audioCollision()
    {
       audio_play(4);
    }
    public void audioDash()
    {
       audio_play(5);
    }
    public void audioHurt()
    {
       audio_play(6);
    }
}