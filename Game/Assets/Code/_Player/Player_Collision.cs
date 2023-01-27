
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MAIN_GAME_OBJECT_SCRIPT
{

    [SerializeField] internal _Player_Script mainScript;
    [SerializeField] internal int pushBack;

    public void setComponent()
    {
        mainScript = GetComponent<_Player_Script>();

    }
    public new void set()
    {
        base.set();
        setComponent();
        pushBack = CONSTANTS.MOVE_KNOCKBACK;

    }

    public void collisionWith_Enemy(Collision2D collision)
    {
        Vector2 direction = (collision.gameObject.transform.position - transform.position).normalized;
        rb2d.AddForce(-pushBack * direction);
    }
    public void collisionWith_Enemy_EXIT(Collision2D collision)
    {
        //flash();
        mainScript.playerSound.audioHurt();
        mainScript.HP.HP_damage(collision.gameObject.GetComponent<Enemy_Health>().damageToPlayer);
        //StartCoroutine(mainScript.Color.flash(mainScript.Color.DEFAULT_PLAYER_COLOR_HURT , 0.1f));
        StartCoroutine(COLOR2.flash(Player_Color.DEFAULT_PLAYER_COLOR_HURT, 0.1f, mainScript.spriterender));

    }
    public void collisionWith_Door(Collider2D other)
    {
        transform.position = other.gameObject.GetComponent<DoorScript>().teleport.position;
    }
    public void collsionWith_Item(Collider2D other)
    {
        ItemScript item = other.gameObject.GetComponent<ItemScript>();
        ScoreManager.scoreChange(item.scoreAdded);
        mainScript.HP.HP_heal(item.HP_Added);
        if (item.HP_Added > item.scoreAdded)
        {
            //StartCoroutine(mainScript.Color.flashing(mainScript.Color.DEFAULT_PLAYER_COLOR_HP_UP, 2, 0.1f));
            StartCoroutine(COLOR2.flash_multiple(Player_Color.DEFAULT_PLAYER_COLOR_HURT, 0.1f, 3, mainScript.spriterender));
        }
        else
        {
            //StartCoroutine(mainScript.Color.flashing(mainScript.Color.DEFAULT_PLAYER_COLOR_DASH, 2, 0.1f));
            StartCoroutine(COLOR2.flash_multiple(Player_Color.DEFAULT_PLAYER_COLOR_DASH, 0.1f, 3, mainScript.spriterender));
        }


    }
    public void collisionWith_Wall(Collision2D collision)
    {
        Color newColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
        spriterender.color = newColor;
    }
    public void collisionWith_Wall_EXIT(Collision2D collision)
    {
        //mainScript.Color.Invoke("resetColor", 2.3f);
        StartCoroutine(COLOR2.transition_self(Player_Color.DEFAULT_PLAYER_COLOR, 2.5f, mainScript.spriterender));

    }
}