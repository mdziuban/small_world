using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedBloodCellSpawner : MonoBehaviour
{
    [SerializeField] Rigidbody bloodCell;
    [SerializeField] Transform[] spawnLocations;
    float speed = 1000f;

    private void Start() {
        StartCoroutine("BloodCellSpawn");
    }

    IEnumerator BloodCellSpawn()
    {
        while (true){
            yield return new WaitForSeconds(Random.Range(.2f, .8f));
            int locationNumber = Random.Range(0,5);
            Rigidbody bloodCellSpawn = Instantiate(bloodCell, spawnLocations[locationNumber].transform.position, spawnLocations[locationNumber].transform.rotation);
            bloodCellSpawn.AddRelativeForce(Vector3.forward * speed);
        }
    }
}
