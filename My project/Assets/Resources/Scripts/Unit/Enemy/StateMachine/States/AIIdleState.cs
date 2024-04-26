using UnityEngine;

public class AIIdleState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }

    public void Enter(UnitEnemy unit)
    {
        Debug.Log("Enter Idle State");
    }

    public void FixedUpdate(UnitEnemy unit)
    {
        Collider2D[] hitColliders = new Collider2D[1];
        int numColliders = Physics2D.OverlapCircleNonAlloc(unit.transform.position, unit.detectionRadius, hitColliders, unit.playerLayer);

        float minDistance = Mathf.Infinity;
        Collider2D nearestPlayerCollider = null;

        for (int i = 0; i < numColliders; i++)
        {
            if (hitColliders[i].gameObject.CompareTag("Player"))
            {
                float distance = Vector2.Distance(unit.transform.position, hitColliders[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPlayerCollider = hitColliders[i];
                }
            }
        }

        if (nearestPlayerCollider != null)
        {
            unit.unitAttack.player = nearestPlayerCollider;
            unit.stateMachine.ChangeState(AiStateId.Follow);
        }
    }

    public void Exit(UnitEnemy unit)
    {
        
    }
}
