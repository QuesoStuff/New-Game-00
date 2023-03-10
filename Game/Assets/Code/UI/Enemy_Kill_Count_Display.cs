using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Kill_Count_Display : GENERIC_UI
{
    new void set()
    {
        base.set();
        textBox.text = "X: " + playerScript.killCount.ToString();
    }
    void display()
    {
        textBox.text = "X: " + playerScript.killCount.ToString();
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
    void UI_UPDATE_High_Score()
    {
        if (playerScript.killCount > saveFile.MAX_KILLS && saveFile.MAX_KILLS > 0)
        {
            newSaveData = true;
            setTextColor(newDisplayColor);
        }
    }

}