using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Sword : MonoBehaviour
{
    public int damage = 1;

    public float damageCooldown = 0.5f;

    //이미 맞은 몬스터 // 중복 데미지 방지
    private List<Collider2D> hitMonster = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            if(!hitMonster.Contains(collision))
            {
                MonsterController monster = collision.GetComponent<MonsterController>();

                if(monster != null)
                {
                    monster.TakeDamage(damage);
                }

                // 맞은 몬스터 리스트에 추가
                hitMonster.Add(collision);

                StartCoroutine(RemoveFromHitList(collision, damageCooldown));
            }
        }
    }

    private IEnumerator RemoveFromHitList(Collider2D monster, float delay)
    {
        //지정된 시간 만큼 대기
        yield return new WaitForSeconds(delay);

        // 쿨다운이 끝난 후 목록에서 제거
        hitMonster.Remove(monster);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
