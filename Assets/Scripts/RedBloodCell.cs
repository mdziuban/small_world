using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class RedBloodCell : MonoBehaviour
{
    [SerializeField] XRBaseInteractable interactable;
    [SerializeField] GameObject virusSpawn;
    [SerializeField] UnityEvent Charged;
    [SerializeField] UnityEvent notCharged;
    [SerializeField] AudioClip chargedSound;
    [SerializeField] AudioClip explodingVirus;
    [SerializeField] AudioSource audioSource;
    GameController gameController;
    Rigidbody _rigidbody;
    bool rbcCharged = false;
    float chargeTime = 0;
    float charged = 3f;


    private void Start() {
        interactable = GetComponent<XRBaseInteractable>();
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(nameof(MoveAround));
        gameController = FindObjectOfType<GameController>();
    }

    private void Update() {
        if (interactable.isSelected == true)
        {
            chargeTime += Time.deltaTime;
            if (chargeTime > charged)
            {
                ChargedState();

            }
        }


    }

    private void ChargedState()
    {
        if (rbcCharged == false)
        {
            rbcCharged = true;
            Charged.Invoke();
            chargeTime = 0;
            audioSource.PlayOneShot(chargedSound);
        }

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Virus" && rbcCharged == true)
        {
            rbcCharged = false;
            audioSource.PlayOneShot(explodingVirus);
            notCharged.Invoke();
            Destroy(other.gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "VirusBullet" && rbcCharged == false)
        {
            GameObject thisVirus = Instantiate(virusSpawn, transform.position, transform.rotation);
            gameController.AddAVirus(thisVirus);
            Destroy(this.gameObject);
        }
    }

    IEnumerator MoveAround()
    {
        while (rbcCharged == false && interactable.isSelected == false)
        {
           
            _rigidbody.AddForce(new Vector3(1*Random.Range(-50,50), 1*Random.Range(-50,50), 1*Random.Range(-50,50)));
             yield return new WaitForSeconds(5f);
        }

    }

}
