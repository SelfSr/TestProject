using UnityEngine;

public class AIDeathState : AiState
{
    public GameObject objectForDrop;
    public AiStateId GetId()
    {
        return AiStateId.Death;
    }
    public void Enter(UnitEnemy unit)
    {
        unit.unitDropSystem.DropItemAfterDead();
        Debug.Log("Enter Death State");
    }
    public void FixedUpdate(UnitEnemy unit)
    {
        
    }

    public void Exit(UnitEnemy unit)
    {
        
    }
}