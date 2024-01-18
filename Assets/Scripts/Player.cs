using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private FloatVariable health;
    [SerializeField] private PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;

	private int score = 0;

    private void Start()
    {
        health.value = 5.5f;
    }

    private void OnEnable()
    {
        gameStartEvent.Subscribe(OnStartGame);
    }

    public int Score {
        get { return score; }
        set { 
            score = value;
            scoreText.text = "Score: " + score.ToString();
            scoreEvent.RaiseEvent(score);
        }
    }

    public void AddPoint(int points)
    {
        Score += points;
    }

    public void OnStartGame()
    {
        characterController.enabled = true;
    }
}
