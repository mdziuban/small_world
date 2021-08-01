using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            Debug.Log("OW!");
        }
        else if (other.tag == "RedBloodCell")
        {
            Debug.Log("Splat");
        }
        Destroy(this.gameObject);
    }
}
