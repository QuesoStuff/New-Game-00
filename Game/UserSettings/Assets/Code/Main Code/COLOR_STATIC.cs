using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class COLOR_STATIC : COLOR
{

    public static void setColor(ref Color currColor , Color newColor)
    {
        currColor = newColor;
    }
    public static void setSpriteRenderColor(ref SpriteRenderer sp , Color newColor)
    {
        sp.color = newColor;
    }

    public static IEnumerator screen_flashing_death( float flashTime)
    {
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.black;
        yield return null;
    }

    public static IEnumerator screen_flashing_time_over(float flashTime , Color color_1 , Color color_2)
    {
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = color_1;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = color_2;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(flashTime);
        Camera.main.backgroundColor = Color.black;
        yield return null;
    }

    public IEnumerator flash(Color colorChange)
    {
        Color originalColor = spriterender.color;
        spriterender.color = colorChange;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        spriterender.color = originalColor;
        yield return null;
    }

    public IEnumerator flash(Color colorChange, float flashTime)
    {
        Color originalColor = spriterender.color;
        spriterender.color = colorChange;
        yield return new WaitForSeconds(flashTime);
        spriterender.color = originalColor;
        yield return null;
    }

    public IEnumerator flashing(Color colorChange, int cycles)
    {
        for (int i = 0; i < cycles; i++)
            flash(colorChange);
        yield return null;
    }

    public IEnumerator flashing(Color colorChange, int cycles, float flashTime)
    {
        for (int i = 0; i < cycles; i++)
            flash(colorChange, flashTime);
        yield return null;
    }





    // functions to be looped
    public static void FadingBackGround(Color color1, Color color2)
    {
        var t = Mathf.PingPong(Time.deltaTime, 3.0F) / 3.0F;
        //t = Mathf.PingPong(Time.time, 3.0F) / 3.0F;
        Camera.main.backgroundColor = Color.Lerp(color1, color2, t);
    }

    public void transitionBackGround(Color color1, Color color2)
    {
        Camera.main.backgroundColor = Color.Lerp(color1, color2, (Time.deltaTime - timeTheFadeStarted) / fadeDuration);
    }




}

