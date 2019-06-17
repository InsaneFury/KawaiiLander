using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayManager : MonoBehaviour
{
    [Header("UISettings")]
    public Text horizontalSpeed;
    public Text verticalSpeed;
    public Text altitude;
    public Text score;
    public Text fuel;

    Player player;

    void Start()
    {
        player = Player.Get();
    }

    void Update()
    {
        RefreshStats();
    }

    void RefreshStats()
    {
        horizontalSpeed.text = player.horizontalSpeed.ToString("F0");
        verticalSpeed.text = player.verticalSpeed.ToString("F0");
        altitude.text = player.altitude.ToString();
        score.text = player.score.ToString();
        fuel.text = player.fuel.ToString();
    }
}
