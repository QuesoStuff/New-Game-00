
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : HEALTH
{
    [SerializeField] internal _Player_Script mainScript;
    [SerializeField] internal int HP_Total_Damage;
    [SerializeField] internal int HP_Total_Heal;

    void setComponent()
    {
        mainScript = GetComponent<_Player_Script>();
    }
    public new void set()
    {
        setComponent();
        base.set();
        HP_Total_Damage = HP_Total_Heal = 0;
    }

    public override void HP_damage()
    {
        HP -= CONSTANTS.HP_DEFAULT_DAMAGE;
        if (HP <= 0)
        {
            HP_Total_Damage += HP;
            HP_Zero();
        }
        else
            HP_Total_Damage += CONSTANTS.HP_DEFAULT_DAMAGE;
    }
    public override void HP_damage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP_Total_Damage += HP;
            HP_Zero();
        }
        else
            HP_Total_Damage += damage;
    }
    public override void HP_heal()
    {
        HP += CONSTANTS.HP_DEFAULT_HEALTH;
        if (HP > HP_Max)
        {
            HP_Total_Heal += HP_Max - CONSTANTS.HP_DEFAULT_HEALTH;
            HP = HP_Max;
        }
        else
            HP_Total_Heal += CONSTANTS.HP_DEFAULT_HEALTH;
    }
    public override void HP_heal(int HP_heal)
    {
        HP += HP_heal;
        if (HP > HP_Max)
        {
            HP_Total_Heal += HP_Max - HP_heal;
            HP = HP_Max;
        }
        else
            HP_Total_Heal += HP_heal;
    }
    public override void HP_fullRestore()
    {
        HP_Total_Heal += HP_Max - HP;
        HP = HP_Max;
    }
    public override void HP_heal_unbounded()
    {
        HP += CONSTANTS.HP_DEFAULT_HEALTH;
        HP_Total_Heal += CONSTANTS.HP_DEFAULT_HEALTH;
    }
    public override void HP_heal_unbounded(int HP_heal)
    {
        HP += HP_Heal;
        HP_Total_Heal += HP_Heal;
    }

    public override void HP_Zero()
    {
        HP = 0;
        StartCoroutine(COLOR2.flash_restart_death());
        Level_Controller_Simple.death_Restart();
    }
}