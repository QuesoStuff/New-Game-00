using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Health : HEALTH
{

    [SerializeField] internal _Player_Script player;
    [SerializeField] internal EnemyScript mainScript;
    [SerializeField] internal int damageToPlayer;

    [SerializeField] internal Object explosionRef;

    public void setComponent()
    {
        mainScript = GetComponent<EnemyScript>();
        player = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();

    }

    public void setRef()
    {
        explosionRef = Resources.Load("Explosion");
    }
    public new void set()
    {
        base.set();
        setRef();
        setComponent();
        damageToPlayer = CONSTANTS.HP_DEFAULT_DAMAGE;
        HP = Random.Range(3, 5);
    }
    public override void HP_damage()
    {
        HP -= CONSTANTS.HP_DEFAULT_DAMAGE;
        if (HP <= 0)
            HP_Zero();
        else
            StartCoroutine(mainScript.Color.whiteFlash());
    }
    public override void HP_damage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
            HP_Zero();
        else
            StartCoroutine(mainScript.Color.whiteFlash());
    }


    public override void HP_Zero()
    {
        mainScript.Controller.speed /= 4;
        GetComponent<BoxCollider2D>().enabled = false;
        mainScript.spriterender.color = Color.white;
        mainScript.Sound.audio_play();
        Destroy(gameObject, (mainScript.Sound.audio_current.clip.length));
        EXPLOSION.explosionCreate(explosionRef, transform.position, mainScript.spriterender.color);
        mainScript.spriterender.enabled = false;
    }

    void OnDestroy()
    {
        player.killCount++;
        ScoreManager.scorechange();
        Random_Level_Gen.enemy_Count--;
    }
}

