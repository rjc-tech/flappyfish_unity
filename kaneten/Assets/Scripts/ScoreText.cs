﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
   public Text scoreText;
   
    void Start()
    {
        
    }

    void Update()
    {
         scoreText.text = FishScoreManager.getScore().ToString();
    }
}
