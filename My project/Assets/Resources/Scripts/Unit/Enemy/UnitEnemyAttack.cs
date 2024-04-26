using UnityEngine;

public class UnitEnemyAttack : MonoBehaviour
{
    [HideInInspector] public Collider2D player;
    public float damage;
    public float attackSpeed = 2f;
    public float attackRange = 2f;

    public void Init()
    {

    }

    public void AttackPlayer()
    {
        if (player != null)
        {
            var damageUnit = player.GetComponent<IDamageable>();
            if (damageUnit != null)
            {
                damageUnit.Damage(damage);
            }
        }
    }
}