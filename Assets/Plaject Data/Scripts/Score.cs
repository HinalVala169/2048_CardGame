using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField]
    private int nMax;

    public int[] numbers;

    [SerializeField]
    private TMP_Text scoreText, highscoreText;
    int score, highscore;

    public void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    public void ScoreSystem(int[] numbers)
    {
        this.numbers = numbers;

        int multiplier = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            score += (numbers[i] + numbers[i]) * multiplier;
            multiplier++;
        }

        scoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = highscore.ToString();
            PlayerPrefs.SetInt("HighScore", highscore);
        }
        
        Debug.Log("The result of the summation is: " + score);
    }
}
