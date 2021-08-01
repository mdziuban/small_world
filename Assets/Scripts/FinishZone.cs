using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    GameController gameController;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && gameController.GetVirusCount() == 0)
        {
            Debug.Log("Game Over!  You win!");
        }
    }
}
