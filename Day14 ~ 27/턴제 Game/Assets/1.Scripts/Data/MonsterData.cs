using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/MonsterData", order = 0)]
public class MonsterData : ScriptableObject
{
    public string pName;
    public string job;
    public int hp;
    public int maxHp;
    public int mp;
    public int maxMp;
    public int attack;
    public int level;
    public int exp;
}
