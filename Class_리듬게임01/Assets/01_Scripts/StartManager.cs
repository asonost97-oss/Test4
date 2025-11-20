//using UnityEditor.Experimental.GraphView; // 주석 처리된 코드 - GraphView 관련 기능이 필요 없어서 비활성화

using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위한 네임스페이스
using UnityEngine.UI; // UI 요소(Button, Slider, Text 등) 사용을 위한 네임스페이스

/// <summary>
/// 시작 화면에서 음악을 선택하고 게임 씬으로 전환하는 매니저 클래스
/// 음악 선택, 볼륨 조절, 씬 전환 기능을 담당합니다.
/// </summary>
public class StartManager : MonoBehaviour
{
    // 오디오 소스 컴포넌트 - 음악 선택 시 재생할 오디오 소스
    // public으로 선언하여 Inspector에서 직접 할당 가능
    public AudioSource playerAudio;

    // 선택 가능한 음악 클립 배열
    // [SerializeField]를 사용하여 private 변수도 Inspector에서 접근 가능하게 함
    // Inspector에서 각 음악의 AudioClip을 드래그 앤 드롭으로 할당
    [SerializeField]
    AudioClip[] selectAudioClips;

    // 현재 선택된 음악의 인덱스 번호
    // 0부터 시작하여 배열의 크기만큼 증가/감소
    [SerializeField]
    int selecNum;

    // 볼륨 조절을 위한 슬라이더 UI
    // Inspector에서 Slider 컴포넌트를 할당
    [SerializeField]
    Slider volumeSlider;

    // 음악 선택 UI 오브젝트 배열
    // 각 음악마다 하나의 GameObject가 있으며, 활성화/비활성화로 표시/숨김 처리
    [SerializeField]
    GameObject[] musicSelects;

    // 선택된 음악의 이름을 저장하는 정적 변수
    // static으로 선언하여 다른 씬에서도 접근 가능 (씬 전환 후에도 값 유지)
    public static string musicName;

    // 선택된 음악의 번호를 저장하는 정적 변수
    // static으로 선언하여 다른 씬에서도 접근 가능 (씬 전환 후에도 값 유지)
    public static int musicNum;

    /// <summary>
    /// 음악 선택 버튼 클릭 시 호출되는 메서드
    /// NextBtn 또는 PrevBtn에 따라 다음/이전 음악으로 이동
    /// </summary>
    /// <param name="btnName">버튼의 이름 ("NextBtn" 또는 다른 값)</param>
    public void MusicBtn(string btnName)
    {
        // NextBtn인 경우: 다음 음악으로 이동
        if (btnName == "NextBtn")
        {
            // 현재 재생 중인 오디오 정지
            // 새로운 음악을 재생하기 전에 이전 음악을 멈춤
            playerAudio.Stop();

            // 현재 선택된 음악 UI를 비활성화 (화면에서 숨김)
            musicSelects[selecNum].SetActive(false);

            // 다음 음악 인덱스로 증가
            selecNum++;

            // 다음 음악 UI를 활성화 (화면에 표시)
            musicSelects[selecNum].SetActive(true);

            // 다음 음악의 미리듣기 오디오 클립을 재생
            // PlayOneShot을 사용하여 기존 오디오와 겹치지 않고 재생
            playerAudio.PlayOneShot(selectAudioClips[selecNum]);
        }
        else // PrevBtn 또는 다른 버튼인 경우: 이전 음악으로 이동
        {
            // selecNum이 0보다 큰 경우에만 실행 (첫 번째 음악이 아닐 때만)
            // 배열의 범위를 벗어나지 않도록 방지
            if (selecNum > 0)
            {
                // 현재 재생 중인 오디오 정지
                playerAudio.Stop();

                // 현재 선택된 음악 UI를 비활성화
                musicSelects[selecNum].SetActive(false);

                // 이전 음악 인덱스로 감소
                selecNum--;

                // 이전 음악 UI를 활성화
                musicSelects[selecNum].SetActive(true);

                // 이전 음악의 미리듣기 오디오 클립을 재생
                playerAudio.PlayOneShot(selectAudioClips[selecNum]);
            }
            // selecNum이 0이면 첫 번째 음악이므로 더 이상 이전으로 갈 수 없음
            // 아무 동작도 하지 않음 (조용히 무시)
        }
    }

    /// <summary>
    /// 로딩 버튼 클릭 시 호출되는 메서드
    /// 선택된 음악 정보를 저장하고 로딩 씬으로 전환
    /// </summary>
    public void LoadingBtn()
    {
        // 현재 선택된 음악 번호를 정적 변수에 저장
        // 다른 씬에서 이 값을 읽어서 어떤 음악을 재생할지 결정
        musicNum = selecNum;

        // 현재 선택된 음악 UI의 자식 오브젝트 중 두 번째(인덱스 1)의 Text 컴포넌트에서
        // 음악 이름을 가져와서 정적 변수에 저장
        // GetChild(1): 두 번째 자식 오브젝트 (첫 번째는 0, 두 번째는 1)
        // GetComponent<Text>(): Text 컴포넌트 가져오기
        // .text: Text 컴포넌트의 텍스트 내용 가져오기
        musicName = musicSelects[selecNum].transform.GetChild(1).GetComponent<Text>().text;

        // "Loading" 씬으로 전환
        // SceneManager.LoadScene()은 씬을 비동기적으로 로드
        // 이전 씬의 모든 오브젝트는 파괴되고 새 씬이 로드됨
        SceneManager.LoadScene("Loading");
    }

    /// <summary>
    /// 게임 시작 시 한 번만 호출되는 초기화 메서드
    /// 컴포넌트 참조를 가져오고 초기 상태를 설정
    /// </summary>
    void Start()
    {
        // 이 GameObject에 붙어있는 AudioSource 컴포넌트를 가져옴
        // GetComponent<>()를 사용하여 컴포넌트 참조 획득
        // Inspector에서 직접 할당하지 않아도 자동으로 찾아서 할당
        playerAudio = GetComponent<AudioSource>();

        // 저장된 음악 번호(musicNum)에 해당하는 오디오 클립을 재생
        // 씬이 다시 로드되었을 때 이전에 선택했던 음악을 자동으로 재생
        // musicNum은 static 변수이므로 씬 전환 후에도 값이 유지됨
        playerAudio.PlayOneShot(selectAudioClips[musicNum]);
    }

    // Update는 매 프레임마다 호출되는 메서드
    // 현재는 사용하지 않으므로 비어있음
    // 필요시 여기에 프레임마다 실행할 로직을 추가할 수 있음
    // 예: 볼륨 슬라이더 값에 따라 오디오 볼륨 조절 등
    void Update()
    {
        // 현재 비어있음
        // 만약 볼륨 슬라이더를 사용한다면 다음과 같이 추가할 수 있음:
        // if(volumeSlider != null)
        // {
        //     playerAudio.volume = volumeSlider.value;
        // }
    }
}