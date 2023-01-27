using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MAIN_GAME_OBJECT_SCRIPT
{
    [SerializeField] internal Enemy_Controller Controller;
    [SerializeField] internal Enemy_Health Health;
    [SerializeField] internal Enemy_Color Color;
    [SerializeField] internal Enemy_Moves Moves;
    [SerializeField] internal Enemy_Collision Collision;
    [SerializeField] internal Enemy_Input INPUT;
    [SerializeField] internal SOUND Sound;
    [SerializeField] internal delegate void funct_ptr();
    [SerializeField] internal funct_ptr moveFunct_ptr;
    [SerializeField] internal int movementConfiguration;

    public void setComponent()
    {
        Controller = GetComponent<Enemy_Controller>();
        Health = GetComponent<Enemy_Health>();
        Color = GetComponent<Enemy_Color>();
        Moves = GetComponent<Enemy_Moves>();
        Collision = GetComponent<Enemy_Collision>();
        INPUT = GetComponent<Enemy_Input>();
        Sound = GetComponent<SOUND>();
    }

    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ENEMY;
        base.set();
        setComponent();
        Controller.set();
        Health.set();
        Color.set();
        Moves.set();
        Collision.set();
        INPUT.set();
        Sound.set();
        movementConfiguration = Random.Range(1, CONSTANTS.ENEMY_MOVE_COUNT) % 4;
    }

    void Start()
    {
        set();
        Moves.chooseMovement(movementConfiguration);
    }

    void Update()
    {
        if (moveFunct_ptr != null)
            moveFunct_ptr();
    }
    void FixedUpdate()
    {
        Controller.Enemy_Move_Fixed();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_BULLET))
        {
            Collision.collisionWith_Bullet(other);
        }
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_TELEPORT))
        {
            Collision.collisionWith_Door(other);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_WALL)
        {
            Collision.collisionWith_Wall(collision);
        }

        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_PLAYER)
        {
            Collision.collisionWith_Player(collision);
        }
    }

}
