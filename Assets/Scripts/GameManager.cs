using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;

    public enum State { 
        TITLE, START_GAME, MAIN_GAME, GAME_OVER
    }

    public State state = State.TITLE;
    private float timer = 0;
    private int lives = 0;

    public int Lives { get { return lives; } set { lives = value; livesUI.text = "LIVES: " + lives.ToString(); } }
    public float Timer { get { return timer; } set { timer = value; timerUI.text = string.Format("{0:F1}", timer); } }

    // Start is called before the first frame update
    void Start()
    {
        scoreEvent.onEventRaised += OnAddPoints;
    }

    // Update is called once per frame
    void Update()
    {
		switch (state)
		{
			case State.TITLE:
                titleUI.SetActive(true);
                gameUI.SetActive(false);
				gameOverUI.SetActive(false);
				Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
				break;

			case State.START_GAME:
                titleUI.SetActive(false);
				gameUI.SetActive(true);
				Timer = 60;
                this.Lives = 3;
                state = State.MAIN_GAME;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
                gameStartEvent.RaiseEvent();
				break;

			case State.MAIN_GAME:
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    state = State.GAME_OVER;
					gameOverUI.SetActive(true);
					gameUI.SetActive(false);
				}
				break;

			case State.GAME_OVER:
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
		}

        healthUI.value = health.value / 100;
	}

    public void StartGame()
    {
        state = State.START_GAME;
    }

    public void RestartGame()
    {
        state = State.TITLE;
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }
}