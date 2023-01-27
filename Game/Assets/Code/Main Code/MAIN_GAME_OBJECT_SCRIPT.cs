using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MAIN_GAME_OBJECT_SCRIPT : MonoBehaviour
{
    [SerializeField] internal Animator animator;
    [SerializeField] internal Rigidbody2D rb2d;
    [SerializeField] internal SpriteRenderer spriterender;

    void OnDestroy()
    {
        gameObject.SetActive(false);
        StopAllCoroutines();
    }
    public void set()
    {
        this.animator = GetComponent<Animator>();
        this.rb2d = GetComponent<Rigidbody2D>();
        this.spriterender = GetComponent<SpriteRenderer>();
    }

    public void increaseSize(int maxSize, float delta)
    {
        Vector2 change = Vector2.zero;
        if (transform.localScale.x < maxSize)
        {
            change.x = transform.localScale.x + delta;
            change.y = transform.localScale.y + delta;
            changeScale(change);
        }
    }
    public void changeScale(float x, float y)
    {
        Vector2 newScale = new Vector2(x, y);
        transform.localScale = newScale;
    }
    public void changeScale(Vector2 newScale)
    {
        transform.localScale = newScale;
    }

    public IEnumerator resizeScale_Square(float startingScale, float endingScale, float fadeDuration)
    {
        Vector2 startSize = new Vector2(startingScale, startingScale);
        Vector2 endSize = new Vector2(endingScale, endingScale);
        transform.localScale = startSize;

        while (fadeDuration > Time.deltaTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, endSize, Time.deltaTime / fadeDuration);
            fadeDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public static IEnumerator resizeScale_Square(float startingScale, float endingScale, float fadeDuration, Transform transform)
    {
        Vector2 startSize = new Vector2(startingScale, startingScale);
        Vector2 endSize = new Vector2(endingScale, endingScale);
        transform.localScale = startSize;

        while (fadeDuration > Time.deltaTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, endSize, Time.deltaTime / fadeDuration);
            fadeDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator resizeScale_Rectangle(float startingScale_x, float startingScale_y, float newScale, float fadeDuration)
    {
        Vector2 startSize = new Vector2(startingScale_x, startingScale_y);
        Vector2 endSize = newScale * startSize;
        transform.localScale = startSize;

        while (fadeDuration > Time.deltaTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, endSize, Time.deltaTime / fadeDuration);
            fadeDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public static IEnumerator resizeScale_Rectangle(float startingScale_x, float startingScale_y, float newScale, float fadeDuration, Transform transform)
    {
        Vector2 startSize = new Vector2(startingScale_x, startingScale_y);
        Vector2 endSize = newScale * startSize;
        transform.localScale = startSize;

        while (fadeDuration > Time.deltaTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, endSize, Time.deltaTime / fadeDuration);
            fadeDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator resizeScale_Rectangle(float startingScale_x, float startingScale_y, float endingScale_x, float endingScale_y, float fadeDuration)
    {
        Vector2 startSize = new Vector2(startingScale_x, startingScale_y);
        Vector2 endSize = new Vector2(endingScale_x, endingScale_y);
        transform.localScale = startSize;

        while (fadeDuration > Time.deltaTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, endSize, Time.deltaTime / fadeDuration);
            fadeDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public static IEnumerator resizeScale_Rectangle(float startingScale_x, float startingScale_y, float endingScale_x, float endingScale_y, float fadeDuration, Transform transform)
    {
        Vector2 startSize = new Vector2(startingScale_x, startingScale_y);
        Vector2 endSize = new Vector2(endingScale_x, endingScale_y);
        transform.localScale = startSize;

        while (fadeDuration > Time.deltaTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, endSize, Time.deltaTime / fadeDuration);
            fadeDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public void pacMan_wrap_around(float x, float y)
    {
        if (transform.position.x > x)
            transform.position = new Vector2(-1 * x, transform.position.y);
        else if (transform.position.x < -1 * x)
            transform.position = new Vector2(x, transform.position.y);
        if (transform.position.y > y)
            transform.position = new Vector2(transform.position.x, -1 * y);
        else if (transform.position.y < -1 * y)
            transform.position = new Vector2(transform.position.x, y);
    }
    public static void pacMan_wrap_around(float x, float y, Transform transform)
    {
        if (transform.position.x > x)
            transform.position = new Vector2(-1 * x, transform.position.y);
        else if (transform.position.x < -1 * x)
            transform.position = new Vector2(x, transform.position.y);
        if (transform.position.y > y)
            transform.position = new Vector2(transform.position.x, -1 * y);
        else if (transform.position.y < -1 * y)
            transform.position = new Vector2(transform.position.x, y);
    }
    public void pacMan_wrap_around(float xMin, float xMax, float yMin, float yMax)
    {
        if (transform.position.x > xMax)
            transform.position = new Vector2(xMin, transform.position.y);
        else if (transform.position.x < xMin)
            transform.position = new Vector2(xMax, transform.position.y);
        if (transform.position.y > yMax)
            transform.position = new Vector2(transform.position.x, yMin);
        else if (transform.position.y < yMin)
            transform.position = new Vector2(transform.position.x, yMax);
    }
    public static void pacMan_wrap_around(float xMin, float xMax, float yMin, float yMax, Transform transform)
    {
        if (transform.position.x > xMax)
            transform.position = new Vector2(xMin, transform.position.y);
        else if (transform.position.x < xMin)
            transform.position = new Vector2(xMax, transform.position.y);
        if (transform.position.y > yMax)
            transform.position = new Vector2(transform.position.x, yMin);
        else if (transform.position.y < yMin)
            transform.position = new Vector2(transform.position.x, yMax);
    }
    public IEnumerator resetValue()
    {
        yield return null;
    }

    public void kill()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
    public void kill(float timer)
    {
        StopAllCoroutines();
        Destroy(gameObject, timer);
    }
}
