using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public float time = 0f;
    public bool gameOver = false;

    UIGameplayManager uigManager;
    ScoreManager sManager;
    public int level = 1;

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
        sManager.AddScore(); 
        gameOver = true;
        uigManager.EnableLandingPanel();
    }

    public void Restart()
    {
        Player.Get().RestartPlayer();
        gameOver = false;
        sManager.scoreAddingCycle = true;
        time = 0;
        uigManager.ActiveLevelPanel();
    }
}
