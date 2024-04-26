public class UnitPlayerHealth : UnitHealth
{
    public override void Init()
    {
        base.Init();
        UIEvents.setBasicHealthUISetUp?.Invoke(maxHealth);
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);
        UIEvents.onHealthChanged?.Invoke(health);
    }

    public override void Die()
    {
        UIEvents.toggleLosePanel?.Invoke(true);
    }
}