using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Music : SOUND
{
    public AudioClip[] otherGameMusic;
    [SerializeField] internal bool not_first_track;

    public new void setComponent()
    {
        //audio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    new void  set()
    {
        base.set();
        setComponent();
        not_first_track = false;
    }
    void Start()
    {
        set();
        if (!GetComponent<AudioSource>().playOnAwake)
        {
            playMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        playMusicRandom();
    }
    public void playMusicRandom()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            playMusic();
            if (not_first_track == true)
            {
                changeRoom();
            }
            not_first_track = true;
        }
    }
    public float randomColorValue()
    {
        return Random.Range(0, 1.0f);
    }
    public void changeRoom()
    {
        float R = randomColorValue();
        float G = randomColorValue();
        float B = randomColorValue();
        //camColor.transitionColor(new Color(R, G, B, 1));
        StartCoroutine(CameraPlayerFollow.transitionColor_Background_No_Update(4.0f, new Color(R, G, B, 1)) );

    }
    public void playMusic()
    {
        GetComponent<AudioSource>().clip = audio_array[Random.Range(0, audio_array.Length)];
        GetComponent<AudioSource>().Play();
    }
    public void playPauseMusic()
    {
        GetComponent<AudioSource>().clip = audio_array[Random.Range(0, audio_array.Length)];
        GetComponent<AudioSource>().Play();
    }
}

