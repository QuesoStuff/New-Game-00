using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Music : SOUND
{
    public AudioClip[] otherGameMusic;
    [SerializeField] internal static bool not_first_track = false;
    [SerializeField] internal static int trackCount = 0;

    public new void setComponent()
    {
        //audio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    new void set()
    {
        base.set();
        setComponent();
    }
    void Start()
    {
        set();
        if (!audio_current.playOnAwake)
            audio_play_music_random();

    }

    // Update is called once per frame
    void Update()
    {
        audio_music_player();
    }
    public void audio_music_player()
    {
        if (!audio_current.isPlaying)
        {
            audio_play_music_random();
            if (not_first_track == true)
            {
                changeRoom();
            }
            not_first_track = true;
            trackCount++;
        }
    }
    public static float randomColorValue()
    {
        return Random.Range(0, 1.0f);
    }
    public void changeRoom()
    {
        float R = randomColorValue();
        float G = randomColorValue();
        float B = randomColorValue();
        StartCoroutine(COLOR2.transition_backGround(new Color(R, G, B, 1) , CameraPlayerFollow.fadeDuration));
    }
    public void audio_play_inRange(int start, int end, AudioClip[] audioCollection)
    {
        audio_current.clip = audioCollection[Random.Range(start, end)];
        audio_current.Play();
    }
    public void audio_play_music_random()
    {
        audio_play_inRange(0, audio_array.Length, audio_array);
        //audio_current.clip = audio_array[Random.Range(0, audio_array.Length)];
        //audio_current.Play();
    }
    public void audio_play_menu_random()
    {
        audio_play_inRange(0, otherGameMusic.Length, otherGameMusic);
        //audio_current.clip = otherGameMusic[Random.Range(0, otherGameMusic.Length)];
        //audio_current.Play();
    }
}

