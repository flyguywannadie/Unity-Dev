using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameWinUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text ScoreUI;

    [SerializeField] GameObject respawn;
    [SerializeField] GameObject startingRespawn;

    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] GameObjectEvent respawnEvent;
    [SerializeField] VoidEvent gameRestartEvent;

    public enum State {
        TITLE, START_GAME, MAIN_GAME, GAME_OVER, GAME_WIN
    }

    public State state = State.TITLE;
    private int lives = 0;
    [SerializeField] private IntVariable score;

    public int Lives { get { return lives; } set { lives = value; livesUI.text = "x " + lives.ToString(); } }
    public int Score { get { return score.value; } set { score.value = value; ScoreUI.text = "Score\n-" + score.value.ToString() + "-"; } }

    // Start is called before the first frame update
    void Start()
    {
        //scoreEvent.onEventRaised += OnAddPoints;
    }

    // Update is called once per frame
    void Update()
    {
    //    switch (state)
    //    {
    //        case State.TITLE:
    //            titleUI.SetActive(true);
    //            gameUI.SetActive(false);
    //            gameOverUI.SetActive(false);
				//gameWinUI.SetActive(false);
				//Cursor.lockState = CursorLockMode.None;
    //            Cursor.visible = true;
    //            break;

    //        case State.START_GAME:
    //            titleUI.SetActive(false);
    //            gameUI.SetActive(true);
    //            state = State.MAIN_GAME;
    //            Cursor.lockState = CursorLockMode.Locked;
    //            Cursor.visible = false;
    //            gameStartEvent.RaiseEvent();
    //            respawnEvent.RaiseEvent(respawn);
    //            break;

    //        case State.MAIN_GAME:
    //            if (this.Lives <= 0)
    //            {
    //                state = State.GAME_OVER;
    //                gameOverUI.SetActive(true);
    //                gameUI.SetActive(false);
    //            }
    //            break;

    //        case State.GAME_OVER:
    //            Cursor.lockState = CursorLockMode.None;
    //            Cursor.visible = true;
    //            break;

    //        case State.GAME_WIN:
    //            Cursor.lockState = CursorLockMode.None;
    //            Cursor.visible = true;
    //            break;
    //    }
    }

    public void StartGame()
    {
        state = State.START_GAME;
        this.Lives = 3;
        this.Score = 0;
		gameRestartEvent.RaiseEvent();
	}

    public void RestartGame()
    {
        state = State.TITLE;
        respawn = startingRespawn;
    }

    public void WinGame()
    {
        gameWinUI.SetActive(true);
		gameUI.SetActive(false);
        state = State.GAME_WIN;
	}

    public void ChangeRespawn(GameObject newspawn)
    {
        respawn = newspawn;
    }

    public void UpdateScore(int score)
    {
        this.Score += score;
    }

    public void OnPlayerDead()
    {
        state = State.START_GAME;
        Lives -= 1;
    }
}