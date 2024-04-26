using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Collider2D spawnArea;

    public void Init()
    {
        SpawnEnemy(3);
    }

    public void SpawnEnemy(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 spawnPoint = RandomPointInBounds(spawnArea);
            GameObject enemyObject = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            UnitEnemy enemy = enemyObject.GetComponent<UnitEnemy>();
            if (enemy != null)
            {
                enemy.Init();
            }
        }
    }


    private Vector2 RandomPointInBounds(Collider2D bounds)
    {
        Vector2 center = bounds.bounds.center;
        Vector2 size = bounds.bounds.size;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomY = Random.Range(center.y - size.y / 2, center.y + size.y / 2);

        return new Vector2(randomX, randomY);
    }
}