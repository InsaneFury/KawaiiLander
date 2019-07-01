using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public float time = 0f;
    public bool gameOver = false;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Player.OnPlayerDie += GameOver;
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
    }

    void Restart()
    {
        gameOver = false;
    }
}
