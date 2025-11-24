using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;

    GameObject[] Player;
    Rigidbody2D rb;

    public bool back = false;
    public Vector3 oriPos;
    Animator ani;

    public int hp;
    public int maxHP;

    public bool home = true;

    //public GameObject magicAura;
    //public Transform T_magicAura;

    //public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oriPos = transform.position;
        ani = GetComponent<Animator>();

        hp = monsterData.hp;
        maxHP = monsterData.maxHp;
    }

    public void NormalAttack()
    {
        if (GameManager.instance.currentTurn == false)
        {
            StartCoroutine("NormalAttackCT");
        }
    }

    IEnumerator NormalAttackCT()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        back = false;
        int r = Random.Range(0, Player.Length);

        while(true)
        {
            if ((Player[r] != null))
            {
                rb.MovePosition(Vector3.Lerp(transform.position, Player[r].transform.position, 20 * Time.deltaTime));

                if(Vector3.Distance(transform.position, Player[r].transform.position) <= 0.5f)
                {
                    ani.SetTrigger("Attack");
                    Player[r].GetComponent<Player>().Damage(monsterData.attack);

                    yield return new WaitForSeconds(0.03f);
                    back = true;
                    break;

                }
            }
            yield return null;
        }
    }

    public void Damage(int attack)
    {
        monsterData.hp -= attack;

        ani.SetTrigger("Damage");

        if (monsterData.hp <= 0)
        {
            GameManager.instance.D_Player.Remove(monsterData.job);

            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (back == true)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, oriPos, 20 * Time.deltaTime));

            if (Vector3.Distance(transform.position, oriPos) <= 0.5f)
            {
                transform.position = oriPos;

                home = true;
            }
        }
    }
}
