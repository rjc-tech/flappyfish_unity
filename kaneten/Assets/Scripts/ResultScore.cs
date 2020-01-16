using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{

    public Text highScoreText;

    public Text scoreText;

    private static int highScore;

    void Start()
    {
        int resultScore = FishScoreManager.getScore();

        Debug.Log("a: " + resultScore);
        Debug.Log("b: " + highScore);

        if (resultScore > highScore)
        {
            highScore = resultScore;
        }

        if (highScoreText != null)
        {
            highScoreText.text = "HIGH SCORE: " + highScore.ToString();
        }
        
        if (scoreText != null)
        {
            scoreText.text = "RESULT SCORE: " + resultScore.ToString();
        }
        
        Debug.Log("highScore: " + highScore.ToString());
        Debug.Log("ResultScore: " + resultScore.ToString());
    }
}
