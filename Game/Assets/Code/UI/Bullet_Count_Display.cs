using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet_Count_Display : GENERIC_UI
{
    [SerializeField] internal int bulletCount;
    [SerializeField] internal Color Color_bulletCount_100;
    new void set()
    {
        base.set();
        Color_bulletCount_100 = Color.yellow;
        textBox.text = bulletCount.ToString();
    }
    public void display()
    {
        bulletCount = playerScript.bullet_shot_Count;
        textBox.text = bulletCount.ToString();
        textColor();
    }
    void textColor()
    {
        if (bulletCount % 75 == 0 && bulletCount > 0)
            setTextColor(Color_bulletCount_100);
        else
            setTextColor(displayColor);
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
        if (bulletCount > saveFile.MAX_BULLET_COUNT && saveFile.MAX_BULLET_COUNT > 0)
        {
            newSaveData = true;
            displayColor = newDisplayColor;
        }
    }
}