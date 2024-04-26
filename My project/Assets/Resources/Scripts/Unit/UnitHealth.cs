using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamageable
{
    [HideInInspector] public float health;
    [SerializeField] protected float maxHealth;

    public virtual void Init()
    {
        health = maxHealth;
    }

    public virtual void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        
    }
}