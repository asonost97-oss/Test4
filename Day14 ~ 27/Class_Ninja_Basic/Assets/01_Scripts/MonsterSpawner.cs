using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;

    public Transform player;

    public float spawnInterval = 3f;

    public float spawnDistance = 10f;

    float timer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 타이머 증가
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnMonster();

            timer = 0f; // 타임머 초기화
        }
    }

    void SpawnMonster()
    {
        if(player == null)
        {
            return;
        }

        // 랜덤한 각도 생성( 0 ~ 360도)
        float randomAngle = Random.Range(0f, 360f);

        float radians = randomAngle * Mathf.Deg2Rad;

        // 원형 범위 내에서 위치 계산 (삼각함수 사용)
        float x = Mathf.Cos(radians) * spawnDistance;

        float y = Mathf.Sin(radians) * spawnDistance;

        Vector3 spawnPosition = player.position + new Vector3(x, y, 0f);

        GameObject monster = Instantiate(monsterPrefab);

        monster.transform.position = spawnPosition;

        //Vector2 spawnPosition = (Vector2)player.position + spawnDirection * spawnDistance;

        //// 몬스터 생성
        //Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
