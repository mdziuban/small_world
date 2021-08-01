using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody _rigidbody;
    void Start()
    {
        Destroy(this.gameObject, 3f);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

}
