using UnityEngine;

public class UnitEnemyDropSystem : MonoBehaviour
{
    public GameObject objectForDrop;
    public void Init()
    {
        
    }

    public void DropItemAfterDead()
    {
        Instantiate(objectForDrop, transform.position, transform.rotation);
    }
}