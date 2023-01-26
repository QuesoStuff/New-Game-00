
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLOR2 : MAIN_GAME_OBJECT_SCRIPT
{
    // if you do decide on producing children with this class
    [SerializeField] internal Color defaultColor;
    [SerializeField] internal Color newColor;

    // COLOR , TIME , CYCLES , (REF)

    // COLOR FLASH (single and multiple flash(es))
    public IEnumerator flash(Color flashColor)
    {
        Color originalColor = spriterender.color;
        spriterender.color = flashColor;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        spriterender.color = originalColor;
        yield return null;
    }
    public static IEnumerator flash(Color flashColor, SpriteRenderer sprite)
    {
        Color originalColor = sprite.color;
        sprite.color = flashColor;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        sprite.color = originalColor;
        yield return null;
    }
    public IEnumerator flash(Color flashColor, float flashTime)
    {
        Color originalColor = spriterender.color;
        spriterender.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        spriterender.color = originalColor;
        yield return null;
    }
    public static IEnumerator flash(Color flashColor, float flashTime, SpriteRenderer sprite)
    {
        Color originalColor = sprite.color;
        sprite.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        sprite.color = originalColor;
        yield return null;
    }
    public IEnumerator flash_multiple(Color flashColor, int cycle)
    {
        Color originalColor = spriterender.color;
        for (int i = 0; i < cycle; i++)
        {
            spriterender.color = flashColor;
            yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
            spriterender.color = originalColor;
            yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        }
        yield return null;
    }
    public static IEnumerator flash_multiple(Color flashColor, int cycle, SpriteRenderer sprite)
    {
        Color originalColor = sprite.color;
        for (int i = 0; i < cycle; i++)
        {
            sprite.color = flashColor;
            yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
            sprite.color = originalColor;
            yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        }
        yield return null;
    }
    public IEnumerator flash_multiple(Color flashColor, float flashTime, int cycle)
    {
        Color originalColor = spriterender.color;
        for (int i = 0; i < cycle; i++)
        {
            spriterender.color = flashColor;
            yield return new WaitForSeconds(flashTime);
            spriterender.color = originalColor;
            yield return new WaitForSeconds(flashTime);
        }
        yield return null;
    }
    public static IEnumerator flash_multiple(Color flashColor, float flashTime, int cycle, SpriteRenderer sprite)
    {
        Color originalColor = sprite.color;
        for (int i = 0; i < cycle; i++)
        {
            sprite.color = flashColor;
            yield return new WaitForSeconds(flashTime);
            sprite.color = originalColor;
            yield return new WaitForSeconds(flashTime);
        }
        yield return null;
    }
    // COLOR TRANSITION (changing color, your own, background)
    public IEnumerator transition(Color oldColor, Color newColor, float transitionDuration)
    {
        while (transitionDuration > Time.deltaTime)
        {
            spriterender.color = Color.Lerp(oldColor, newColor, Time.deltaTime / transitionDuration);
            transitionDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        spriterender.color = newColor;
        yield return null;
    }
    public static IEnumerator transition(Color oldColor, Color newColor, float transitionDuration, SpriteRenderer sprite)
    {
        while (transitionDuration > Time.deltaTime)
        {
            sprite.color = Color.Lerp(oldColor, newColor, Time.deltaTime / transitionDuration);
            transitionDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        sprite.color = newColor;
        yield return null;
    }
    public IEnumerator transition_self(Color newColor, float transitionDuration)
    {
        StartCoroutine(transition(spriterender.color, newColor, transitionDuration));
        yield return null;
    }
    public static IEnumerator transition_self(Color newColor, float transitionDuration, SpriteRenderer sprite)
    {
        while (transitionDuration > Time.deltaTime)
        {
            sprite.color = Color.Lerp(sprite.color, newColor, Time.deltaTime / transitionDuration);
            transitionDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        sprite.color = newColor;
        yield return null;
    }
    public static IEnumerator transition_backGround(Color newColor, float transitionDuration)
    {
        while (transitionDuration > Time.deltaTime)
        {
            Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, newColor, Time.deltaTime / transitionDuration);
            transitionDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Camera.main.backgroundColor = newColor;
        yield return null;
    }
    // COLOR FADE (FADE IN/OUT SINGLE)
    public IEnumerator fade_out_self(float transitionDuration)
    {
        //Color fadedColor = spriterender.color - new Color(0, 0, 0, 1);
        Color fadedColor = spriterender.color;
        fadedColor.a = 0;
        StartCoroutine(transition(spriterender.color, fadedColor, transitionDuration));
        yield return null;
    }
    public static IEnumerator fade_out_self(float transitionDuration, SpriteRenderer sprite)
    {
        //Color fadedColor = sprite.color - new Color(0, 0, 0, 1);
        Color fadedColor = sprite.color;
        fadedColor.a = 0;
        while (transitionDuration > Time.deltaTime)
        {
            sprite.color = Color.Lerp(sprite.color, fadedColor, Time.deltaTime / transitionDuration);
            transitionDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        sprite.color = fadedColor;
        yield return null;
    }
    public IEnumerator fade_in_self(float transitionDuration)
    {
        //Color fadedColor = sprite.color - new Color(0, 0, 0, 1);
        float end = spriterender.color.a;
        float start = 0;
        float alpha = start;
        Color originalCopy = spriterender.color;
        while (transitionDuration > Time.deltaTime && alpha < 1)
        {
            alpha += (end - start) / (transitionDuration / Time.deltaTime);
            transitionDuration -= Time.deltaTime;
            Debug.Log(alpha);
            originalCopy.a = alpha;
            spriterender.color = originalCopy;
            yield return new WaitForEndOfFrame();
        }
        originalCopy.a = end;
        spriterender.color = originalCopy;
        yield return null;
    }
    public static IEnumerator fade_in_self(float transitionDuration, SpriteRenderer sprite)
    {
        //Color fadedColor = sprite.color - new Color(0, 0, 0, 1);
        float end = sprite.color.a;
        float start = 0;
        float alpha = start;
        Color originalCopy = sprite.color;
        while (transitionDuration > Time.deltaTime && alpha < 1)
        {
            alpha += (end - start) / (transitionDuration / Time.deltaTime);
            transitionDuration -= Time.deltaTime;
            Debug.Log(alpha);
            originalCopy.a = alpha;
            sprite.color = originalCopy;
            yield return new WaitForEndOfFrame();
        }
        originalCopy.a = end;
        sprite.color = originalCopy;
        yield return null;
    }
    // COLOR BLINKING (FADE IN/OUT OR OTHER COLORS)
    public void blinking_in_out_self(float transitionDuration)
    {
        spriterender.color = new Color(spriterender.color.r, spriterender.color.g, spriterender.color.b, Mathf.PingPong(Time.unscaledTime / transitionDuration, 1));
    }
    public static void blinking_in_out_self(float transitionDuration, SpriteRenderer sprite)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.PingPong(Time.unscaledTime / transitionDuration, 1));
    }
    public static void blinking_two_colors_backGround(Color blinkingColor1, Color blinkingColor2)
    {
        Camera.main.backgroundColor = Color.Lerp(blinkingColor1, blinkingColor2, Mathf.Sin(Time.time));
    }
    public static void blinking_two_colors_backGround(Color blinkingColor1, Color blinkingColor2, float transitionDuration)
    {
        Camera.main.backgroundColor = Color.Lerp(blinkingColor1, blinkingColor2, Mathf.Sin(Time.time));
    }
    public void blinking_two_colors_self(Color blinkingColor1, Color blinkingColor2)
    {
        spriterender.color = Color.Lerp(blinkingColor1, blinkingColor2, Mathf.Sin(Time.time));
    }
    public static void blinking_two_colors_self(Color blinkingColor1, Color blinkingColor2, SpriteRenderer sprite)
    {
        sprite.color = Color.Lerp(blinkingColor1, blinkingColor2, Mathf.Sin(Time.time));
    }
    public void blinking_two_colors_self(Color blinkingColor1, Color blinkingColor2, float transitionDuration)
    {
        spriterender.color = Color.Lerp(blinkingColor1, blinkingColor2, Mathf.Sin(Time.time));
    }
    public static void blinking_two_colors_self(Color blinkingColor1, Color blinkingColor2, float transitionDuration, SpriteRenderer sprite)
    {
        sprite.color = Color.Lerp(blinkingColor1, blinkingColor2, Mathf.Sin(Time.time));
    }
    // COLOR BACKGROUND RESET FUNCTIONS
    public static IEnumerator flash_restart_death()
    {
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return null;
    }
    public IEnumerator flash_restart_timeUp()
    {
        Color wall_color = new Color(0.9339623f, 0.5850481f, 0.5850481f, 1);
        Color player_color = new Color(0.4588f, 0.8198f, 0.6941f, 1);
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = wall_color;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = player_color;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return null;
    }
}