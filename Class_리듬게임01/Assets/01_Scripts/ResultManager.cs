using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    ScorePoint score;

    [SerializeField]
    public Text perfectText;
    public Text goodText;
    public Text badText;
    public Text missText;

    public Text rateText;

    GameObject homeBtn;
    
    void Start()
    {
        perfectText.text = ScorePoint.perfectPoint.ToString();
        goodText.text = ScorePoint.goodPoint.ToString();
        badText.text = ScorePoint.badPoint.ToString();
        missText.text = ScorePoint.missPoint.ToString();

        if(ScorePoint.score > 200)
        {
            rateText.text = "A";
        }else if(ScorePoint.score < 200 && ScorePoint.score > 150)
        {
            rateText.text = "B";
        }else if(ScorePoint.score < 150 && ScorePoint.score > 100)
        {
            rateText.text = "C";
        }else if(ScorePoint.score < 100 && ScorePoint.score > 50)
        {
            rateText.text = "D";
        }else if(ScorePoint.score < 50)
        {
            rateText.text = "E";
        }
    }

    public void HomeBtn()
    {
        ScorePoint.perfectPoint = 0;
        ScorePoint.goodPoint = 0;
        ScorePoint.badPoint = 0;
        ScorePoint.missPoint = 0;
        ScorePoint.score = 0;

        SceneManager.LoadScene("Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
