using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EntityBehavior : MonoBehaviour
{
    [FormerlySerializedAs("Health")] public int MaxHealth;
    public float MainAttackCooldown = 2;
    public float SpecialAttackCooldown = 10;
    public int MainAttackDamage = 6;
    protected float mainAttackTimer = 0;
    protected float specialAttackTimer = 0;
    protected bool mainAttackReady = false;
    protected bool specialAttackReady = false;
    protected int currentHealth;
    /// <summary>
    /// Previous Health, Current Health, Max Health
    /// </summary>
    public Action<float, float, float> OnHealthChanged;

    public Action<EntityBehavior> OnDeath;
    protected virtual void Awake()
    {
        currentHealth = MaxHealth;
        mainAttackTimer = MainAttackCooldown;
        specialAttackTimer = SpecialAttackCooldown;
    }
    public virtual void Update()
    {
        if (!mainAttackReady && mainAttackTimer < 0)
        {
            mainAttackReady = true;
        }

        if (!specialAttackReady && specialAttackTimer < 0)
        {
            specialAttackReady = true;
        }
        
        mainAttackTimer -= Time.deltaTime;
        specialAttackTimer -= Time.deltaTime;

    }

    protected virtual void MainAttack(EntityBehavior target)
    {
        mainAttackTimer = MainAttackCooldown;
        mainAttackReady = false;
        target.TakeDamage(MainAttackDamage);
    }

    protected virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        OnHealthChanged?.Invoke(currentHealth + damage, currentHealth, MaxHealth);
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke(this);
    }
    
    
}
