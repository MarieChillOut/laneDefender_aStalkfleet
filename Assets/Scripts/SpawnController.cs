using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject snail;
    [SerializeField] private GameObject worm;
    [SerializeField] private GameObject greenSlime;

    private int r_min;
    private int r_max;
    private float enemyNum;
    
    private int laneNum;
    private float repeat;

    private Vector3 spawnLocation;

    private float[] lanePos = {0.25f, -1.45f, -3.45f, -5.45f, -7.15f};

    void Start()
    {
        repeat = 3.0f;
        r_min = 0;
        r_max = 100;

        spawnLocation = new Vector3(19.5f, 0, 0);
        InvokeRepeating("Spawn", 0.2f, repeat);
    }

    public void PausedGame()
    {
        StopCoroutine("Spawn");
    }

    private void Spawn()
    {
        enemyNum = Random.Range(r_min, r_max);
        RandomLane();
        if (enemyNum <= 40)
        {
            Instantiate(worm, spawnLocation, Quaternion.identity);
        }
        else if (enemyNum <= 90 && enemyNum >= 50)
        {
            Instantiate(greenSlime, spawnLocation, Quaternion.identity);
        }
        else
        {
            Instantiate(snail, spawnLocation, Quaternion.identity);
        }
    }

    private void RandomLane()
    {
        laneNum = Random.Range(0,4);
        spawnLocation.y = lanePos[laneNum];

    }
}
