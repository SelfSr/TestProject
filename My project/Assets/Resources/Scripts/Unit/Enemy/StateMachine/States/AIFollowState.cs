using UnityEngine;

public class AIFollowState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Follow;
    }

    public void Enter(UnitEnemy unit)
    {
        Debug.Log("Enter Follow State");
    }

    public void FixedUpdate(UnitEnemy unit)
    {
        float distance = Vector3.Distance(unit.unitAttack.player.transform.position, unit.transform.position);

        if (distance <= unit.unitAttack.attackRange)
            unit.stateMachine.ChangeState(AiStateId.Attack);

        if (distance > unit.detectionRadius)
            unit.stateMachine.ChangeState(AiStateId.Idle);

        Vector3 direction = (unit.unitAttack.player.transform.position - unit.transform.position).normalized;

        if (direction.x > 0)
            unit.sprite.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (direction.x < 0)
            unit.sprite.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        unit.transform.Translate(direction * unit.unitSpeed * Time.deltaTime);
    }

    public void Exit(UnitEnemy unit)
    {

    }
}