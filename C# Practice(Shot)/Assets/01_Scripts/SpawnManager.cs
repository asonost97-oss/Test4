using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    
    void Start()
    {
        SpawnEnemy(enemy1Prefab, new Vector3(1, 2, 0));

        SpawnEnemy(enemy2Prefab, new Vector3(-1, 2, 0));
    }

    public void SpawnEnemy(GameObject prefab, Vector3 position)
    {
        GameObject enemy = Instantiate(prefab);

        enemy.transform.position = position;

        enemy.GetComponent<Enemy>().Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
