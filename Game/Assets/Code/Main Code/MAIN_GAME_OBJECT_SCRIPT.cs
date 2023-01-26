using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MAIN_GAME_OBJECT_SCRIPT : MonoBehaviour
{
    // UNITY FIELD OBJECTS
    [SerializeField] internal Animator animator; // affects the pl animation (still to run to jump and so on)
    [SerializeField] internal Rigidbody2D rb2d;  // deals with movement, vectors
    [SerializeField] internal SpriteRenderer spriterender; // graphical part, flips sprite if need be



    // SET & CONSTRUCTOR 
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

    public IEnumerator resizeScale(float fadeDuration, float startingScale, float endingScale)
    {
        Vector2 startSize = new Vector2(startingScale, startingScale);
        transform.localScale = startSize;
        Vector2 endSize = new Vector2(endingScale, endingScale);

        while (fadeDuration > Time.deltaTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, endSize, Time.deltaTime / fadeDuration);
            fadeDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }


}
