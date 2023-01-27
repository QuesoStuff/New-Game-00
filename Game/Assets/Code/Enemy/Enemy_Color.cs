using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Color : COLOR2
{
    [SerializeField] internal EnemyScript mainScript;
    [SerializeField] internal Color DEFAULT_ENEMY_COLOR;
    [SerializeField] internal float opacityDecrementer;
    [SerializeField] internal float RGB_Red_to_White;
    [SerializeField] internal float RGB_Green_to_White;
    [SerializeField] internal float RGB_Blue_to_White;
    [SerializeField] internal int starting_opacity;
    // defaultColor

    public void setComponent()
    {
        mainScript = GetComponent<EnemyScript>();
    }
    public void setRef()
    {
    }
    void calculateColor0()
    {
        defaultColor.r = (float)mainScript.Health.damageToPlayer / (float)CONSTANTS.ENEMY_DAMAGE_MAX;
        defaultColor.g = (float)mainScript.Health.HP / (float)CONSTANTS.ENEMY_HP_MAX;
        defaultColor.b = (float)mainScript.Controller.speed / (float)CONSTANTS.MOVE_MAX_ENEMY_SPEED;
        defaultColor.a = starting_opacity;
        spriterender.color = defaultColor;
    }
    void calculateColor1()
    {
        opacityDecrementer = (float)starting_opacity / (float)mainScript.Health.HP;
        opacityDecrementer = -opacityDecrementer;
        RGB_Red_to_White = (1 - defaultColor.r) / (float)mainScript.Health.HP;
        RGB_Green_to_White = (1 - defaultColor.g) / (float)mainScript.Health.HP;
        RGB_Blue_to_White = (1 - defaultColor.b) / (float)mainScript.Health.HP;
    }



    public new void set()
    {
        base.set();
        starting_opacity = 1;
        setComponent();
        calculateColor0();
        calculateColor1();
        base.resetColor();
        spriterender.enabled = true;
        opacityDecrementer = 0;
    }


    public IEnumerator whiteFlash()
    {
        spriterender.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        updateColor();
        updateColor();
        resetColor();
    }


    public void updateColor()
    {
        defaultColor += new Color(RGB_Red_to_White, RGB_Green_to_White, RGB_Blue_to_White, opacityDecrementer);
    }
}