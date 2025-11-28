using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 0)]
public class PlayerData : ScriptableObject
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
