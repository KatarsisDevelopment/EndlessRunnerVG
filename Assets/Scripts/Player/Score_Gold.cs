using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score_Gold : MonoBehaviour
{
    //Score
    public float Score;
    float HighScore;
    //Gold
    public float Gold;
    //UI
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI ScoreText;
    public  TextMeshProUGUI HighScoreText;
    void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HScore");
        Gold = PlayerPrefs.GetFloat("GoldCount");
    }
    void Update()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetFloat("HScore", Score);
        }
        Score += 1 * Time.deltaTime;
        GoldText.text = "" + Gold;
        ScoreText.text = "Score :" + Score.ToString("0");
        HighScoreText.text = "High Score :" + HighScore.ToString("0");
    }
    void CollectGold()
    {
        Gold += 1;
        PlayerPrefs.SetFloat("GoldCount", Gold);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            CollectGold();
            other.gameObject.SetActive(false);
        }
    }
}
