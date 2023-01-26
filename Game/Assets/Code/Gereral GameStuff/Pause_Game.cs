using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Game : MonoBehaviour
{
    [SerializeField] internal GameObject soundBox;
    [SerializeField] internal Random_Music audioScript;
    [SerializeField] static internal bool isPaused = false;


    // Start is called before the first frame update
    void setComponent()
    {
        soundBox = GameObject.Find("Game_Manager").transform.GetChild(0).gameObject;
        audioScript = soundBox.GetComponent<Random_Music>();
    }
    void set()
    {
        setComponent();
    }
    void Start()
    {
        set();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1 - Time.timeScale;
            if (Time.timeScale == 0)
            {
                audioScript.audio_play_menu_random();
                isPaused = true;
            }
            else
            {
                audioScript.audio_play_music_random();
                isPaused = false;
            }
        }
    }
}