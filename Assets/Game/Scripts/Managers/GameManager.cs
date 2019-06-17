using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonobehaviourSingleton<GameManager>
{
    public float time = 0f;

    public override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        time = Time.time;
    }
}
