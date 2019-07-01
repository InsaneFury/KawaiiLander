using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonobehaviourSingleton<ScoreManager>
{
    [HideInInspector]
    public float score = 0f;
    public float scoreToAdd = 100f;
    public bool scoreAddingCycle = true;

    GameManager gManager;
    Player player;
    

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        player = Player.Get();
        gManager = GameManager.Get();
        Player.OnPlayerVictory += AddScore;
    }

    public void AddScore()
    {
        if (player.isGrounded)
        {
            score += scoreToAdd;
        }
        else
        {
            score = 0;
        }
    }
}
