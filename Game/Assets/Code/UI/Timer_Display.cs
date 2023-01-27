using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Display : GENERIC_UI
{
    [SerializeField] internal int min;
    [SerializeField] internal int sec;

    [SerializeField] internal float flashTImer;
    [SerializeField] internal float currTime;

    [SerializeField] internal Color timer_Color_Half;
    [SerializeField] internal Color timer_Color_Quarter;
    [SerializeField] internal Color timer_End_Less_Than_60_SEC;



    // Use this for initialization

    new void set()
    {
        base.set();
        convertTime();
        textBox.text = min.ToString() + " : " + sec.ToString();
        timer_Color_Half = Color.yellow;
        timer_Color_Quarter = new Color(1.0f, 0.64f, 0.0f, 1);
        timer_End_Less_Than_60_SEC = Color.red;
        flashTImer = 0.25f;
    }
    void Start()
    {
        set();
    }
    void Update()
    {
        display();
        if (newSaveData == false)
            UI_UPDATE_High_Score();
    }
    void display()
    {
        convertTime();
        textColor();
        textProperFormat();
    }
    void convertTime()
    {
        currTime = Clock.CurrentTime;
        min = (int)currTime / 60;
        sec = (int)currTime % 60;
    }
    void textColor()
    {
        if (currTime < 60)
            setTextColor(timer_End_Less_Than_60_SEC);
        else if (currTime < CONSTANTS.TIME_IN_LEVEL / 4)
            setTextColor(timer_Color_Quarter);
        else if (currTime < CONSTANTS.TIME_IN_LEVEL / 2)
            setTextColor(timer_Color_Half);
    }
    void textProperFormat()
    {
        if (sec > 10)
            textBox.text = min.ToString() + " : " + sec.ToString();
        else
            textBox.text = min.ToString() + " : 0" + sec.ToString();
    }
    void UI_UPDATE_High_Score()
    {
        if (currTime < saveFile.TIME_LEFT && saveFile.TIME_LEFT < Clock.CLOCK_COUNTDOWM_START)
        {
            newSaveData = true;
            //StartCoroutine(newSurivalTimeIndicator(flashTImer));
            StartCoroutine(COLOR2.blinking_text(textBox , flashTImer , 3));

        }            

    }



}