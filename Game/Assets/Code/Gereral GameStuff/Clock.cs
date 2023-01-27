using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] internal static float CurrentTime; // in secs
    [SerializeField] internal static int CLOCK_TIMER_LIMIT; // in secs
    [SerializeField] internal static int CLOCK_COUNTDOWM_START = CONSTANTS.TIME_IN_LEVEL; // in secs




    // Use this for initialization
    public void set()
    {
        setCountDown();
    }
    public void setTimer()
    {
        CurrentTime = 0;
    }
    public void setCountDown()
    {
        CurrentTime = CLOCK_COUNTDOWM_START;
    }
    public void Start()
    {
        set();
    }
    public void Update()
    {
        clock_countDown_update();
    }
    // Update is called once per frame
    public void clock_countDown_update()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(COLOR2.flash_restart_timeUp());
            Level_Controller_Simple.timer_end_Restart();
        }
    }
    public void clock_timer_update()
    {
        if (CurrentTime < CLOCK_TIMER_LIMIT)
        {
            CurrentTime += Time.deltaTime;
        }
        else
        {
            StartCoroutine(COLOR2.flash_restart_timeUp());
            Level_Controller_Simple.timer_end_Restart();
        }
    }
}