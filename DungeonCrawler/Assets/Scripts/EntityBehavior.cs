using System;
using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
    public float MainAttackCooldown = 2;

    public float SpecialAttackCooldown = 10;

    public float MainAttackDamage = 6;

    private float mainAttackTimer = 0;
    private float specialAttackTimer = 0;

    protected virtual void Awake()
    {
        mainAttackTimer = MainAttackCooldown;
        specialAttackTimer = SpecialAttackCooldown;
    }

    public virtual void Update()
    {
        if (mainAttackTimer < 0)
        {
            mainAttackTimer = MainAttackCooldown;
        }

        if (specialAttackTimer < 0)
        {
            specialAttackTimer = SpecialAttackCooldown;
        }
        
        mainAttackTimer -= Time.deltaTime;
        specialAttackTimer -= Time.deltaTime;

    }

    protected virtual void Attack(EntityBehavior target)
    {
        
    }
}
