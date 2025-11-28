using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSettingsData : IUserData
{
    public bool sound { get; set; } // »ç¿îµå ¼³Á¤ (ÄÑÁü/²¨Áü)

    public void SetDefaultData()
    {
        Logger.Log($"{GetType()}::SetDefaultData()");

        sound = true; // ±âº»°ª : »ç¿îµå ÄÑÁü
    }

    public bool LoadData()
    {
        Logger.Log($"{GetType()}::LoadData()");

        bool result = false;

        try
        {
            sound = PlayerPrefs.GetInt("Sound") == 1 ? true : false;

            result = true;

            Logger.Log($"Sound: {sound}");
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
            PlayerPrefs.SetInt("Sound", sound ? 1 : 0);

            PlayerPrefs.Save();

            result = true;

            Logger.Log($"Sound: {sound}");
        }
        catch (System.Exception e)
        {
            Logger.Log("Save failed(" + e.Message + ")");
        }

        return result;
    }
}
