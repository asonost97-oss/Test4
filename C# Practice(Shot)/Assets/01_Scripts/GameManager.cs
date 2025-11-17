using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ItemManager itemManager;
    public GameObject Cover;

    int score;
    public Text scroreText;
    public Text bestScoreText;

    UserData userData;
    
    void Start()
    {
        LoadUserData();

        EventManager.EnemyDieEvent += OnEnemyDie;

        bestScoreText.text = string.Format("Best Sore: {0}", userData.bestScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        Cover.SetActive(false);

        spawnManager.SpawnRandom();

        itemManager.SpawnRandom();
    }

    public void OnEnemyDie()
    {
        score++;
        scroreText.text = string.Format("Score: {0}", score);

        if(userData.bestScore < score)
        {
            userData.bestScore = score;
            bestScoreText.text = string.Format("Best Score: {0}", userData.bestScore);

            SaveUserData();            
        }
    }

    void SaveUserData()
    {
        FileStream file =
        new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Create);

        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(file, userData);

        file.Close();
    }

    void LoadUserData()
    {
        if (File.Exists(Application.persistentDataPath + "/userdata.dat"))
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            userData = (UserData)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            userData = new UserData();
        }
    }

    /// <summary>
    /// 사용자 데이터를 저장하기 위한 직렬화 가능한 클래스
    /// </summary>

    [Serializable]
    class UserData
    {
        public int bestScore;

    }

    /// <summary>
    /// 저장된 사용자 데이터를 파일에서 로드하는 함수
    /// 파일 존재 여부를 먼저 확인한 후 안전하게 데이터를 불러옴
    /// </summary>
    /*void LoadUserData()
    {
        // 사용자 데이터 파일이 존재하는지 먼저 확인
        // Application.persistentDataPath: 영구 저장 가능한 디렉토리 경로
        // File.Exists(): 지정된 경로에 파일이 존재하면 true, 없으면 false 반환
        if (File.Exists(Application.persistentDataPath + "/userdata.dat"))
        {
            // 파일이 존재하는 경우: 저장된 데이터를 로드

            // 파일을 읽기 전용으로 열기
            // FileMode.Open: 기존 파일만 열기 (파일이 없으면 예외 발생하지만, 이미 존재 확인함)
            FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Open);

            // 바이너리 데이터를 객체로 변환하기 위한 포맷터 생성
            BinaryFormatter bf = new BinaryFormatter();

            // 파일에서 바이너리 데이터를 읽어와서 UserData 객체로 역직렬화
            // bf.Deserialize()는 Object 타입을 반환하므로 UserData로 명시적 캐스팅 필요
            userData = (UserData)bf.Deserialize(file);

            // 파일 스트림을 닫아서 시스템 리소스 해제
            file.Close();

            // 디버깅용 로그 (선택사항)
            // Debug.Log("기존 사용자 데이터 로드 완료 - 최고 점수: " + userData.BestScore);
        }
        else
        {
            // 파일이 존재하지 않는 경우: 새로운 사용자 데이터 생성
            // 첫 번째 게임 실행이거나 데이터 파일이 삭제된 경우에 해당
            userData = new UserData();

            // 디버깅용 로그 (선택사항)
            // Debug.Log("저장된 데이터가 없어 새로운 사용자 데이터 생성");
        }
    }*/
}
