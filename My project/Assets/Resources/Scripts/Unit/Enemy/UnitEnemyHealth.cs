using UnityEngine;
using UnityEngine.UI;

public class UnitEnemyHealth : UnitHealth
{
    [SerializeField] private Slider healthSlider;

    private UnitEnemy unitEnemy;
    public override void Init()
    {
        base.Init();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        unitEnemy = GetComponent<UnitEnemy>();
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);
        healthSlider.value = health;
    }

    public override void Die()
    {
        base.Die();
        AIDeathState deathState = unitEnemy.stateMachine.GetState(AiStateId.Death) as AIDeathState;
        unitEnemy.stateMachine.ChangeState(AiStateId.Death);
        Destroy(gameObject);
    }
}
