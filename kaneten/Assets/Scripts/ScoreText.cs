using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

   public Text scoreText;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         scoreText.text = FishScoreManager.getScore().ToString();
    }
}
