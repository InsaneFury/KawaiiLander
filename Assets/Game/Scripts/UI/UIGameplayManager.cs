using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayManager : MonobehaviourSingleton<UIGameplayManager>
{
    [Header("UISettings")]
    public Text horizontalSpeed;
    public Text verticalSpeed;
    public Text altitude;
    public Text score;
    public Text fuel;
    public Text time;

    [Header("LandingPanel")]
    public GameObject landingPanel;
    public GameObject gameOverUI;
    public GameObject victoryUI;

    Player player;
    GameManager gManager;
    ScoreManager sManager;

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        player = Player.Get();
        gManager = GameManager.Get();
        sManager = ScoreManager.Get();
    }

    void Update()
    {
        RefreshStats();
    }

    void RefreshStats()
    {
        horizontalSpeed.text = player.horizontalSpeed.ToString("F0");
        verticalSpeed.text = player.verticalSpeed.ToString("F0");
        altitude.text = player.altitude.ToString("F0") + "mts";
        score.text = sManager.score.ToString();
        fuel.text = player.fuel.ToString("F1");
        time.text = gManager.time.ToString("F1") + "s";
    }

    public void EnableLandingPanel()
    {
        landingPanel.SetActive(true);
        if (player.isGrounded)
        {
            victoryUI.SetActive(true);
        }
        else if (!player.isGrounded)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void DisableLandingPanel()
    {
        landingPanel.SetActive(false);
        victoryUI.SetActive(false);
        gameOverUI.SetActive(false);
    }
}
