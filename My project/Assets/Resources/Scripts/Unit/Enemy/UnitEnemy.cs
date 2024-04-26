using UnityEngine;

public class UnitEnemy : MonoBehaviour
{
    [HideInInspector] public UnitEnemyHealth unitHealth;
    [HideInInspector] public UnitEnemyDropSystem unitDropSystem;
    [HideInInspector] public UnitEnemyAttack unitAttack;

    [HideInInspector] public AiStateMachine stateMachine;
    public GameObject sprite;
    public AiStateId initialState;

    public float unitSpeed = 5f;

    public bool debug = true;
    public float detectionRadius = 10f;
    public LayerMask playerLayer;

    public void Init()
    {
        stateMachine = new AiStateMachine(this);

        unitHealth = GetComponent<UnitEnemyHealth>();
        unitDropSystem = GetComponent<UnitEnemyDropSystem>();
        unitAttack = GetComponent<UnitEnemyAttack>();

        if (unitHealth != null)
            unitHealth.Init();

        if (unitDropSystem != null)
            unitDropSystem.Init();

        if (unitAttack != null)
            unitAttack.Init();

        stateMachine.RegisterState(new AIIdleState());
        stateMachine.RegisterState(new AIDeathState());
        stateMachine.RegisterState(new AIFollowState());
        stateMachine.RegisterState(new AIAttackState());
        stateMachine.ChangeState(initialState);
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}