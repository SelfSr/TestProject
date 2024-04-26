public enum AiStateId
{
    Idle,
    Death,
    Follow,
    Attack
}
public interface AiState
{
    AiStateId GetId();
    void Enter(UnitEnemy unit);
    void FixedUpdate(UnitEnemy unit);
    void Exit(UnitEnemy unit);
}
