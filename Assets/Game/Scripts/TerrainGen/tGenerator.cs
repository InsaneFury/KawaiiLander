using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tGenerator : MonoBehaviour
{
    [Header("Settings")]
    public GameObject[] prefabs;
    public int amount = 5;
    public Vector2 startPosition;

    List<GameObject> terrains;

    void Start()
    {
        terrains = new List<GameObject>();
        Create();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Create();
        }
    }

    public void Create()
    {
        if (terrains.Count > 0)
        {
            foreach (GameObject go in terrains)
            {
                Destroy(go);
            }

            terrains.Clear();
        }
        Vector2 spawnPos = startPosition;
        Vector2 offset = new Vector2(prefabs[0].GetComponentInChildren<SpriteRenderer>().bounds.size.x,0);
        
        int tRand = Mathf.RoundToInt(Random.Range(0f, prefabs.Length-1));
        GameObject currentT = Instantiate(prefabs[tRand], spawnPos, Quaternion.identity);
        spawnPos += offset;
        terrains.Add(currentT);

        for (int i = 1; i < amount; i++)
        {
            tRand = Mathf.RoundToInt(Random.Range(0f,prefabs.Length-1));
            currentT = Instantiate(prefabs[tRand], spawnPos, Quaternion.identity);
            spawnPos += offset;
            terrains.Add(currentT);
        }
    }
}
