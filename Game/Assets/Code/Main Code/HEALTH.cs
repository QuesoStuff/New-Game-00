
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HEALTH : MonoBehaviour, I_HEALTH
{
    [SerializeField] internal int HP_Max;
    [SerializeField] internal int HP;
    [SerializeField] internal int HP_Damage;
    [SerializeField] internal int HP_Heal;
    public void set()
    {
        this.HP = CONSTANTS.HP_DEFAULT_STARTER_HP;
        this.HP_Max = this.HP;
        this.HP_Damage = CONSTANTS.HP_DEFAULT_DAMAGE;
        this.HP_Heal = CONSTANTS.HP_DEFAULT_HEALTH;
    }
    public virtual void HP_damage()
    {
        HP -= CONSTANTS.HP_DEFAULT_DAMAGE;
        if (HP <= 0)
        HP_Zero();
    }
    public virtual void HP_damage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        HP_Zero();
    }
    public virtual void HP_heal()
    {
        HP += CONSTANTS.HP_DEFAULT_HEALTH;
        if (HP > HP_Max)
        HP = HP_Max;
    }
    public virtual void HP_heal(int HP_heal)
    {
        HP += HP_Heal;
        if (HP > HP_Max)
        HP = HP_Max;
    }
    public virtual void HP_fullRestore()
    {
        HP = HP_Max;
    }
    public virtual void HP_heal_unbounded()
    {
        HP += CONSTANTS.HP_DEFAULT_HEALTH;
    }
    public virtual void HP_heal_unbounded(int HP_heal)
    {
        HP += HP_Heal;
    }
    public virtual void HP_increaseMaxHealth()
    {
        HP_Max += CONSTANTS.HP_DEFAULT_HEALTH;
    }
    public virtual void HP_increaseMaxHealth(int HP_Extra)
    {
        HP_Max += HP_Extra;
    }
    public virtual void HP_Zero()
    {
        Destroy(gameObject);
    }


}