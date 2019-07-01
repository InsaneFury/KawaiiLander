using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public float time = 0f;
    public bool gameOver = false;

    UIGameplayManager uigManager;
    ScoreManager sManager;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        uigManager = UIGameplayManager.Get();
        sManager = ScoreManager.Get();
        Player.OnPlayerDie += GameOver;
        Player.OnPlayerVictory += GameOver;
    }

    void Update()
    {
        if(!gameOver)
        {
            time = Time.time;
        }
    }

    void GameOver()
    {
        gameOver = true;
        uigManager.EnableLandingPanel();
    }

    void Restart()
    {
        Player.Get().RestartPlayer();
        gameOver = false;
        sManager.startScorePerTime();
    }
}
