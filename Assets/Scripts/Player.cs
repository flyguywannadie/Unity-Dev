using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    

    private int score = 0;
    private float health = 100;

    public int Score {
        get { return score; }
        set { score = value; scoreText.text = "Score: " + score.ToString(); }
    }

    public void AddPoint(int points)
    {
        Score += points;
    }
}
