
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player_Script : MAIN_GAME_OBJECT_SCRIPT
{

    // ADDED SCRIPTS (internal allows to be accessed)
    [SerializeField] internal Player_Collision Collision; // engage with game world items
    [SerializeField] internal Player_Health HP;
    [SerializeField] internal Player_Color Color;
    [SerializeField] internal Player_Controller Controller;
    [SerializeField] internal Player_Input INPUT;
    [SerializeField] internal Player_Sound playerSound;


    [SerializeField] internal int killCount;
    [SerializeField] internal int bullet_shot_Count;
    [SerializeField] internal float total_Distance_traveled;


    void setComponent()
    {
        Collision = GetComponent<Player_Collision>();
        HP = GetComponent<Player_Health>();
        Color = GetComponent<Player_Color>();
        Controller = GetComponent<Player_Controller>();
        INPUT = GetComponent<Player_Input>();
        playerSound = GetComponent<Player_Sound>();
    }
    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_PLAYER;
        setComponent();
        base.set();
        Collision.set();
        HP.set();
        Controller.set();
        Color.set();
        INPUT.set();
        playerSound.set();
        killCount = 0;
        total_Distance_traveled = 0;
        bullet_shot_Count = 0;
    }
    void Awake()
    {
        set();
    }
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

        // NEED A GAME OBJECT HANDLER VERY SOON
        //Controller.player_Moving();  ultimate_direction_input
        if (!Pause_Game.isPaused)
        {
            Controller.ultimate_Player_Moving();
            Controller.playerDash();
            Controller.ultimate_Player_Shooting();
            Controller.shooting();
            Controller.charged_Shooting();
            Controller.RecordDistance();
            // TESTING SPECIAL ATTACKS
            if (Input.GetKeyDown(KeyCode.A))
            {
                BulletScript.item1 = !BulletScript.item1;
                Debug.Log("item1: " + BulletScript.item1);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                BulletScript.item2 = !BulletScript.item2;
                Debug.Log("item2: " + BulletScript.item2);
            }
        }
    }
    // Update is called once per frame (for physics and fixed frameRate)
    public void FixedUpdate()
    {
        Controller.player_Move_Fixed();
    }


    // COLLISION
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Item interactions
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_ITEM))
        {
            Collision.collsionWith_Item(other);
        }
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_TELEPORT))
        {
            Collision.collisionWith_Door(other);
            playerSound.audioTeleport();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_ENEMY)
        {
            Collision.collisionWith_Enemy(collision);
            playerSound.audioCollision();
        }
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_WALL)
        {
            Collision.collisionWith_Wall(collision);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_WALL)
        {
            Collision.collisionWith_Wall_EXIT(collision);
        }
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_ENEMY)
        {
            Collision.collisionWith_Enemy_EXIT(collision);
        }
    }


}

