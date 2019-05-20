using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highscoreManager : MonoBehaviour
{
    public static float getHighScore()//get
    {
        return PlayerPrefs.GetFloat("HighScore");
    }

    public static void setHighScore(float score)//set
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetFloat("HighScore", score);
        
    }
}
