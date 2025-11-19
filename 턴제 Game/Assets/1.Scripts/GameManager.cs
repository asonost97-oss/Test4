using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Dictionary<string, GameObject> D_Player = new Dictionary<string, GameObject>();

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    public GameObject[] status;
    Text[] swordmanTxt;
    Text[] priestTxt;
    Text[] witchTxt;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        D_Player.Add("검사", player1); // 검사: key, player1: value
        D_Player.Add("신관", player2);
        D_Player.Add("마법사", player3);

        status = GameObject.FindGameObjectsWithTag("Status");

        swordmanTxt = status[0].GetComponentsInChildren<Text>();
        priestTxt = status[1].GetComponentsInChildren<Text>();
        witchTxt = status[2].GetComponentsInChildren<Text>();

    }

    private void Update()
    {
        StatusShow();
    }

    //상태표시함수
    void StatusShow()
    {
        //딕셔너리에서 검사를 찾아야한다.
        if (D_Player.ContainsKey("검사"))
        {
            //소드맨오브젝트
            PlayerController P = D_Player["검사"].GetComponent<PlayerController>();

            if (P != null)
            {
                //플레이어 가져옴
                swordmanTxt[0].text = P.PlayerData.job;
                swordmanTxt[1].text = "레벨             " + P.PlayerData.level;
                swordmanTxt[2].text = "경험치         " + P.PlayerData.exp;
                swordmanTxt[3].text = "HP           " + P.PlayerData.hp + "/" + P.PlayerData.maxHp;
                swordmanTxt[4].text = "MP           " + P.PlayerData.hp + "/" + P.PlayerData.maxHp;
            }
        }

        //딕셔너리에서 신관을 찾아야한다.
        if (D_Player.ContainsKey("신관"))
        {
            //소드맨오브젝트
            PlayerController P2 = D_Player["신관"].GetComponent<PlayerController>();

            if (P2 != null)
            {
                //플레이어 가져옴
                priestTxt[0].text = P2.PlayerData.job;
                priestTxt[1].text = "레벨             " + P2.PlayerData.level;
                priestTxt[2].text = "경험치         " + P2.PlayerData.exp;
                priestTxt[3].text = "HP           " + P2.PlayerData.hp + "/" + P2.PlayerData.maxHp;
                priestTxt[4].text = "MP           " + P2.PlayerData.hp + "/" + P2.PlayerData.maxHp;
            }
        }

        //딕셔너리에서 마법사를 찾아야한다.
        if (D_Player.ContainsKey("마법사"))
        {
            //소드맨오브젝트
            PlayerController P3 = D_Player["마법사"].GetComponent<PlayerController>();

            if (P3 != null)
            {
                //플레이어 가져옴
                witchTxt[0].text = P3.PlayerData.job;
                witchTxt[1].text = "레벨             " + P3.PlayerData.level;
                witchTxt[2].text = "경험치         " + P3.PlayerData.exp;
                witchTxt[3].text = "HP           " + P3.PlayerData.hp + "/" + P3.PlayerData.maxHp;
                witchTxt[4].text = "MP           " + P3.PlayerData.hp + "/" + P3.PlayerData.maxHp;
            }
        }
    }
}
