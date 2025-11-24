using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData playerData;

    GameObject[] Monster;
    Rigidbody2D rb;

    public bool back = false;
    public Vector3 oriPos;
    Animator ani;

    public bool home = true;

    public GameObject magicAura;
    public Transform T_magicAura;

    public GameObject explosion;
    

    void Start()
    {
        Monster = GameObject.FindGameObjectsWithTag("Monster");

        rb = GetComponent<Rigidbody2D>();

        oriPos = transform.position;

        ani = GetComponent<Animator>();
    }

    public void NormalAttack()
    {
        if(GameManager.instance.currentTurn == false && home)
        {
            StartCoroutine("NormalAttackCT");
        }
    }

    IEnumerator NormalAttackCT()
    {
        Monster = GameObject.FindGameObjectsWithTag("Monster");

        back = false;

        int r = Random.Range(0, Monster.Length);

        while(true)
        {
            if (Monster[r] != null)
            {
                rb.MovePosition(Vector3.Lerp(transform.position, Monster[r].transform.position, 20 * Time.deltaTime));

                home = false;

                if (Vector3.Distance(transform.position, Monster[r].transform.position) <= 0.5f)
                {
                    ani.SetTrigger("Attack"); 

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
        playerData.hp -= attack;

        ani.SetTrigger("Damage");

        if(playerData.hp <= 0)
        {
            GameManager.instance.D_Player.Remove(playerData.job);

            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(back == true)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, oriPos, 20 * Time.deltaTime));

            if(Vector3.Distance(transform.position, oriPos) <= 0.5f)
            {
                transform.position = oriPos;

                home = true;
            }
        }
    }
}
