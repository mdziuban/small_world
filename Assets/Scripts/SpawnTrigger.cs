using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] VirusSpawner virusSpawner;
    bool alreadyTriggered = false;

    private void Start() {
        virusSpawner = GetComponentInParent<VirusSpawner>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && alreadyTriggered == false)
        {
            virusSpawner.StartSpawn();
            alreadyTriggered = true;
        }
    }
}
