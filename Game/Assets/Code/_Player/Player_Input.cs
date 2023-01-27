
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : INPUT
{
    [SerializeField] internal _Player_Script playerScript;
    [SerializeField] internal bool chargeReady;
    public new void set()
    {
        base.set();
        playerScript = GetComponent<_Player_Script>();
        chargeReady = false;
    }
    public override bool input_charged_Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            base.timer_input_press_shoot = Time.time;
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - base.timer_input_press_shoot > CONSTANTS.CHARGED_SHOT_TIME_READY && chargeReady == false)
            {
                //StartCoroutine(playerScript.Color.chargeShootReady());
                StartCoroutine(COLOR2.flash(Player_Color.DEFAULT_PLAYER_COLOR_BIG_SHOOT_READY, playerScript.Controller.dashingTime , playerScript.spriterender));
                chargeReady = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            chargeReady = false;
            var startPress = base.timer_input_press_shoot;
            if (Time.time - startPress >= CONSTANTS.CHARGED_SHOT_TIME)
            {
                //StartCoroutine(playerScript.Color.shoot());
                StartCoroutine(COLOR2.flash(Player_Color.DEFAULT_PLAYER_COLOR_BIG_SHOOT_READY, playerScript.Controller.dashingTime , playerScript.spriterender));
                return true;
            }
        }
        return false;
    }
}