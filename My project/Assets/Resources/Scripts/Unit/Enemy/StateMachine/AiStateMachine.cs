public class AiStateMachine
{
    public AiState[] states;
    public AiStateId currentState;
    public UnitEnemy unitEnemy;

    public AiStateMachine(UnitEnemy unit)
    {
        unitEnemy = unit;
        int numStates = System.Enum.GetNames(typeof(AiStateId)).Length;
        states = new AiState[numStates];
    }
    public void RegisterState(AiState state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }
    public AiState GetState(AiStateId stateId)
    {
        int index = (int)stateId;
        return states[index];
    }
    public void FixedUpdate()
    {
        GetState(currentState)?.FixedUpdate(unitEnemy);
    }
    public void ChangeState(AiStateId newState)
    {
        GetState(currentState)?.Exit(unitEnemy);
        currentState = newState;
        GetState(currentState)?.Enter(unitEnemy);
    }
}