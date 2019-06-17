using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonobehaviourSingleton<ScoreManager>
{
    [HideInInspector]
    public float score = 0f;
    public float scorePerSecond = 10f;
    GameManager gManager;

    void Start()
    {
        gManager = GameManager.Get();
        InvokeRepeating("ScorePerTime", 0f, 1f);
    }

    void ScorePerTime()
    {
        score += scorePerSecond;
    }
}
