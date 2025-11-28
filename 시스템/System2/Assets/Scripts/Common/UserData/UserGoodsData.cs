using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGoodsData : IUserData
{
    public long Gem { get; set; } // 보석

    public long Gold { get; set; } // 코인

    public void SetDefaultData() // 초기화
    {
        Logger.Log($"{GetType()}::SetDefaultData()");

        Gem = 0; // 기본값 : 보석 1000

        Gold = 0; // 기본값 : 코인 5000
    }

    public bool LoadData()
    {
        Logger.Log($"{GetType()}::LoadData()");

        bool result = false;

        try
        {
            Gem = long.Parse(PlayerPrefs.GetString("Gem"));
            Gold = long.Parse(PlayerPrefs.GetString("Gold"));
            result = true;

            Logger.Log($"Gem: {Gem}, Gold: {Gold}");
        }
        catch (System.Exception e)
        {
            Logger.Log("Load failed(" + e.Message + ")");
        }

        return result;
    }

    public bool SaveData()
    {
        Logger.Log($"{GetType()}::SaveData()");

        bool result = false;

        try
        {
            PlayerPrefs.SetString("Gem", Gem.ToString());
            PlayerPrefs.SetString("Gold", Gold.ToString());
            PlayerPrefs.Save();

            result = true;

            Logger.Log($"Gem: {Gem}, Gold: {Gold}");
        }
        catch (System.Exception e)
        {
            Logger.Log("Save failed(" + e.Message + ")");
        }
        return result;
    }
}
