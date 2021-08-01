using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusFireController : MonoBehaviour
{
    [SerializeField] Rigidbody virusBullet;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fireSound;
    float attackTimer = 0f;
    float attackInterval = 2f;
    float bulletSpeed = 80f;
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" || other.tag == "RedBloodCell")
        {
            if (Time.time > attackTimer)
            {
                attackTimer = Time.time + attackInterval;
                audioSource.PlayOneShot(fireSound);
                Rigidbody spawnedBullet = Instantiate(virusBullet, this.transform.position, this.transform.rotation);
                spawnedBullet.velocity = (other.transform.position - spawnedBullet.transform.position).normalized * bulletSpeed;
            }
        }
    }
}
