using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;
    [SerializeField] GameObjectEvent respawnEvent = default;

	private int score = 0;

    private void Start()
    {

    }

    private void OnEnable()
    {
        gameStartEvent.Subscribe(OnStartGame);
    }

    public int Score {
        get { return score; }
        set { 
            score = value;//
            scoreText.text = score.ToString();
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

	public void OnRestartGame()
	{
        Score = 0;
	}

	public void Hurt(float damage)
    {
        playerDeadEvent.RaiseEvent();
		characterController.enabled = false;
	}

    public void OnRespawn(GameObject respawn)
    {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        characterController.Reset();
    }
}
