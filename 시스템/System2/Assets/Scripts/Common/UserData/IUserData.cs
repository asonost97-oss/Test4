using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserData // 다중 상속을 위한 인터페이스
{
    void SetDefaultData();

    bool LoadData();

    bool SaveData();
}
