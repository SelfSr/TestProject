using UnityEngine;

public class AIAttackState : AiState
{
    private float timeSinceLastAttack = 0f;

    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }

    public void Enter(UnitEnemy unit)
    {
        Debug.Log("Enter Attack State");
    }

    public void FixedUpdate(UnitEnemy unit)
    {
        if (timeSinceLastAttack > 0f)
            timeSinceLastAttack -= Time.deltaTime;

        float distance = Vector3.Distance(unit.unitAttack.player.transform.position, unit.transform.position);

        if (distance > unit.unitAttack.attackRange)
            unit.stateMachine.ChangeState(AiStateId.Follow);

        if (timeSinceLastAttack <= 0f)
        {
            unit.unitAttack.AttackPlayer();
            timeSinceLastAttack = unit.unitAttack.attackSpeed;
        }
    }

    public void Exit(UnitEnemy unit)
    {

    }
}