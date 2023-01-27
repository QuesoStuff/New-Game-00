using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code in relation to bullet/projectile FIRST ONE
public class BulletScript : MAIN_GAME_OBJECT_SCRIPT
{
    // fields & variable creation
    [SerializeField] internal static bool item1 = false;
    [SerializeField] internal static bool item2 = false;
    [SerializeField] internal float speed;
    [SerializeField] internal float x;
    [SerializeField] internal float y;
    [SerializeField] internal int bulletDamage;
    [SerializeField] internal static int bulletShotCount = 0;
    [SerializeField] internal Color currColor;
    [SerializeField] internal Color colorSpeed_0;
    [SerializeField] internal Color colorSpeed_1;
    [SerializeField] internal Color colorSpeed_2;
    [SerializeField] internal Color colorSpeed_3;
    [SerializeField] internal float lifeTime;
    [SerializeField] internal Object explosionRef;
    [SerializeField] internal Object explosionRef2;
    [SerializeField] internal Object explosionRef3;
    [SerializeField] internal Object explosionRef4;
    [SerializeField] internal SOUND Sound;
    [SerializeField] internal Vector2 bulletSpeed;
    [SerializeField] internal BoxCollider2D col;

    public void setRef()
    {
        explosionRef = Resources.Load("explosion_bullet_collision");
        explosionRef2 = Resources.Load("explosion_wall");
        explosionRef3 = Resources.Load("hit,blood");
        explosionRef4 = Resources.Load("explosion_dash");
        Sound = GetComponent<SOUND>();
        col = GetComponent<BoxCollider2D>();
    }
    
    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_BULLET;
        setRef();
        base.set();
        speed = 5;
        lifeTime = 3.21f;
        BulletScript.bulletShotCount++;
        kill(4 * lifeTime);
        Invoke("changeCounter", lifeTime);
        colorSet();
        Sound.set();
    }
    void colorSet()
    {
        colorSpeed_0 = new Color(0.4588f, 0.8198f, 0.6941f, 1); // greeen 
        colorSpeed_1 = new Color(0.0811f, 0.7202f, 0.9056f, 1); //blue
        colorSpeed_2 = new Color(0.9056f, 0.6538f, 0.0811f, 1); //orange
        colorSpeed_3 = new Color(0.9056f, 0.2959f, 0.0811f, 1); //red
    }
    void Start()
    {
        set();
        bullet_shape();
        bullet_color();
        bullet_speed();
        bullet_damage();
    }
    void changeCounter()
    {
        if (bulletShotCount > 0)
            BulletScript.bulletShotCount--;
    }
    void laser_horizontal(float scale)
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;

        changeScale(scale * x, 1 * y);
    }
    void laster_vertical(float scale)
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        changeScale(1 * x, scale * y);
    }
    void laser_create(float scale_H, float scale_V)
    {
        if ((x != 0 && y == 0))
            laser_horizontal(scale_H);
        if ((x == 0 && y != 0))
            laster_vertical(scale_V);
    }
    void bullet_shape()
    {
        if (BulletScript.bulletShotCount < 2)
        {
            laser_create(3.5f, 3.5f);
            var x = transform.localScale.x;
            var y = transform.localScale.y;
            StartCoroutine(resizeScale_Rectangle(0, 0, x, y, 0.40f));
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_PERFECT)
        {
            laser_create(3.0f, 3.0f);
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_0)
        {
            laser_create(2.0f, 2.0f);
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_1)
        {
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_2)
        {
            laser_create(1.15f, 1.15f);
        }
        else
        {
            laser_create(1.15f, 1.15f);
        }
    }
    void bullet_speed()
    {
        if (BulletScript.bulletShotCount < 2)
        {
            bulletSpeed = new Vector2(x, y) * speed / 2;
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_0)
        {
            rb2d.velocity = new Vector2(x, y) * speed;
            bulletSpeed = new Vector2(x, y) * speed;
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_1)
        {
            rb2d.velocity = new Vector2(x, y) * speed / 2;
            bulletSpeed = new Vector2(x, y) * speed / 2;
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_2)
        {
            rb2d.velocity = new Vector2(x, y) * speed / 2;
            bulletSpeed = Vector2.zero;
        }
        else
        {
            rb2d.velocity = new Vector2(x, y) * speed / 4;
            bulletSpeed = Vector2.zero;
        }
    }
    void bullet_color()
    {
        if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_0)
            currColor = colorSpeed_0;
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_1)
            currColor = colorSpeed_1;
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_2)
        {
            currColor = colorSpeed_2;
        }
        else
        {
            currColor = colorSpeed_3;
        }
        spriterender.color = currColor;
    }
    void bullet_damage()
    {
        if (BulletScript.bulletShotCount < 2)
        {
            this.bulletDamage = this.bulletDamage * 3;
        }
        else if (BulletScript.bulletShotCount < 3)
        {
            this.bulletDamage = this.bulletDamage + 1;
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_0)
        {
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_1)
        {
            this.bulletDamage = this.bulletDamage + 2;
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_2)
            this.bulletDamage = this.bulletDamage * 2;
        else
            this.bulletDamage = this.bulletDamage * 4;
    }
    void OnDestroy()
    {
        Debug.Log(" class");
        EXPLOSION.explosionCreate(explosionRef3, transform.position, spriterender.color);
        changeCounter();
        StopAllCoroutines();

    }
    void Update()
    {
        if (item1)
        {
            bullet_speed();
            bullet_color();
        }
    }
    private void FixedUpdate()
    {
        rb2d.velocity += bulletSpeed;
    }
    void OnBecameInvisible()
    {
        kill(lifeTime);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_WALL))
        {
            EXPLOSION.explosionCreate(explosionRef, transform.position, other.gameObject.GetComponent<SpriteRenderer>().color);
            spriterender.color = currColor;
            bulletSpeed = new Vector2(x / 2, y / 2);
            kill(lifeTime / 2);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == CONSTANTS.COLLISION_TAG_ENEMY)
        {
            Sound.audio_play();
            spriterender.color = other.gameObject.GetComponent<SpriteRenderer>().color;
            EXPLOSION.explosionCreate(explosionRef, transform.position, spriterender.color);
            kill(GetComponent<AudioSource>().clip.length);
        }
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_TELEPORT))
        {
            Debug.Log("teleport");
            if (item2)
            {
                transform.position = other.gameObject.GetComponent<DoorScript>().teleport.position;
                bulletSpeed = new Vector2(-y, -x);
            }
            else
            {
                spriterender.color = other.gameObject.GetComponent<SpriteRenderer>().color;
                EXPLOSION.explosionCreate(explosionRef4, transform.position, spriterender.color);
                EXPLOSION.explosionCreate(explosionRef, transform.position, spriterender.color);
                kill();
            }
        }

        if (other.CompareTag(CONSTANTS.COLLISION_TAG_WALL))
        {
            spriterender.color = other.gameObject.GetComponent<SpriteRenderer>().color;
            EXPLOSION.explosionCreate(explosionRef2, transform.position, spriterender.color);
            bulletSpeed = new Vector2(-x / 8, -y / 8);
        }
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_ITEM))
        {
            var top = Random.Range(0, CONSTANTS.BULLET_SIM_SPEED_MAX);
            var bottom = Random.Range(1, CONSTANTS.BULLET_SIM_SPEED_MAX);
            var factor = top / bottom;
            if (factor % 8 == 0)
            {
                bulletSpeed = new Vector2(factor * factor * -y, factor * factor * -x);
                rb2d.velocity = new Vector2(bottom * rb2d.velocity.x, top * rb2d.velocity.y);
                return;
            }
            if (top % 2 == 1)
                x = -x;
            if (bottom % 2 == 1)
                y = -y;
            if (factor % 2 == 0)
            {
                var yTemp = y;
                y = x;
                x = yTemp;
            }
            bulletSpeed = new Vector2(factor * x, factor * y);
            lifeTime += (lifeTime / 2);
            spriterender.color = other.gameObject.GetComponent<SpriteRenderer>().color;
        }
    }
 
}

