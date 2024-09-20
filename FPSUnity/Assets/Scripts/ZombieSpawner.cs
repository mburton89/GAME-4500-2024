using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public GameObject zombiePrefab;
    public List<Transform> spawnPoints;

    int wave;

    private void Awake()
    {
        Instance = this;
        wave = 1;
        HUD.Instance.UpdateWaveUI(wave);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        { 
            SpawnWaveOfZombies();
        }
    }

    void SpawnWaveOfZombies()
    {
        wave++;

        for (int i = 0; i < wave; i++)
        { 
            int rand = Random.Range(0, spawnPoints.Count);
            Instantiate(zombiePrefab, spawnPoints[rand].position, transform.rotation, transform);
        }

        HUD.Instance.UpdateWaveUI(wave);
    }

    public void CountZombies()
    {
        Zombie[] allZombiesInScene = FindObjectsByType<Zombie>(FindObjectsSortMode.None);

        if (allZombiesInScene.Length == 1)
        {
            SpawnWaveOfZombies();
        }
    }
}
