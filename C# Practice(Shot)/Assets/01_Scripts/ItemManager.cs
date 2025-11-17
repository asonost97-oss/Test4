using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Point[] points = { new Point(0, 0),
        new Point(1, 1),
        new Point(1, -1), 
        new Point(-1, 1),
        new Point(-1, -1),
        new Point(2, 2),
        new Point(2, -2), 
        new Point(-2, -2), 
        new Point(3, 3), 
        new Point(3, -3), 
        new Point(-3, 3), 
        new Point(-3, 3), 
        new Point(-3, -3)
    };

    public GameObject[] itemPrefabs = new GameObject[3]; // 배열
    
    void Start()
    {
        //for (int i = 0; i < 3; i++)
        //{
        //    GameObject prefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

        //    Vector2 pos = points[Random.Range(0, points.Length)].GetPos();

        //    SpawnItem(prefab, pos);
        //}
    }

    public void SpawnItem(GameObject itemPrefab, Vector2 position)
    {
        GameObject obj = Instantiate(itemPrefab); // 생성

        obj.transform.position = position; // 위치 입히기
    }

    public void SpawnRandom()
    {
        GameObject prefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

        Vector2 pos = points[Random.Range(0, points.Length)].GetPos();

        SpawnItem(prefab, pos);

        Invoke("SpawnRandom", 1f); // 재귀
    }

   
}
public struct Point // class
{
    public int x;

    public int y;

    public Point(int x, int y)
    {
        this.x = x;

        this.y = y;
    }

    public Vector2 GetPos()
    {
        return new Vector2(x, y);
    }
}
