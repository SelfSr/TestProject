using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float timeToDestroy;

    private void Start()
    {
        Invoke(nameof(DestroyMeObj), timeToDestroy);
    }

    private void DestroyMeObj()
    {
        Destroy(gameObject);
    }
}