using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject enemy1Prefab;
    //public GameObject enemy2Prefab;

    public GameObject[] enemyPrefabs;

    public Point[] points =
    {
        new Point(-3, -5),
        new Point(-3, -3),
        new Point(-3, -1),
        new Point(-3, 1),
        new Point(-3, 3),
        new Point(-3, 5),
        new Point(3, -5),
        new Point(3, -3),
        new Point(3, -1),
        new Point(3, 1),
        new Point(3, 3),
        new Point(3, 5),
    };
    
    void Start()
    {
        SpawnRandom();
    }

    public void SpawnEnemy(GameObject prefab, Vector3 position)
    {
        GameObject enemy = Instantiate(prefab);

        enemy.transform.position = position;

        enemy.GetComponent<Enemy>().Move();
    }

    public void SpawnRandom()
    {
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Vector2 pos = points[Random.Range(0, points.Length)].GetPos();

        SpawnEnemy(prefab, pos);

        Invoke("SpawnRandom", 0.3f); // Àç±Í
    }
}
