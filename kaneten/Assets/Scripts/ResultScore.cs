using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{

    public Text scoreText;

    void Start()
    {
        int s = FishScoreManager.getScore();

        scoreText.text = "ResultScore: " + s.ToString();
        Debug.Log("score: " + s.ToString());
    }
}
