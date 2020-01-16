using UnityEngine;
using System.Collections;

public class FishScoreManager : MonoBehaviour
{
    private static int score = 0;

    public static void addPoint(int point)
    {
       score += point;
    }

    public static int getScore()
    {
       return score;
    }
    
    public static void resetScore()
    {
       score = 0;
    }

}
