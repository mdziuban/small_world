using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnLocation;
    [SerializeField] GameObject virus;
    GameController gameController;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }
    
    public void StartSpawn()
    {
        SpawnViruses();

    }


    private void SpawnViruses()
    {
        foreach (var spawn in spawnLocation)
        {
            GameObject thisVirus = Instantiate(virus, spawn.position, spawn.rotation);
            gameController.AddAVirus(thisVirus);
        }
    }

}
