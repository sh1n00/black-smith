using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; set; } = 0;
    
    public void ScorePlus(int num)
    {
        Score += num;
        Debug.Log(Score);
    }
}
