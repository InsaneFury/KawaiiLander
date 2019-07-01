using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonobehaviourSingleton<ScoreManager>
{
    [HideInInspector]
    public float score = 0f;
    public float scorePerSecond = 10f;
    GameManager gManager;

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        gManager = GameManager.Get();
        startScorePerTime();
    }

    private void Update()
    {
        if (gManager.gameOver)
        {
            CancelInvoke("ScorePerTime");
        }
    }

    void ScorePerTime()
    {
        score += scorePerSecond;
    }

    public void startScorePerTime()
    {
        InvokeRepeating("ScorePerTime", 0f, 1f);
    }
}
