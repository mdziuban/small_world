using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class Virus : MonoBehaviour
{

    XRBaseInteractable interactable;
    [SerializeField] GameObject fireController;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deadVirus;
    [SerializeField] AudioClip chargedVirus;
    GameController gameController;
    Rigidbody _rigidBody;
    bool isAlive = true;
    bool isCharged = false;
    float chargeTime = 0f;
    float charged = 3f;

    [SerializeField] UnityEvent alive;
    [SerializeField] UnityEvent dead;

    private void Start() {
        interactable = GetComponent<XRBaseInteractable>();
        _rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(nameof(MoveAround));
        isAlive = true;
        gameController = FindObjectOfType<GameController>();
    }

    private void Update() {
        if (isAlive == true && interactable.isSelected == true)
        {
            chargeTime += Time.deltaTime;
            if (chargeTime > charged)
            {
                ChargedState();
                chargeTime = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Laser")
        {
            isAlive = false;

            dead.Invoke();
            audioSource.PlayOneShot(deadVirus);
            fireController.SetActive(false);
            gameController.RemoveAVirus();
            
        }
        else if (isCharged == true)
        {
            _rigidBody.AddExplosionForce(1000, transform.position, 100);
            Destroy(this.gameObject);
        }
    }

    private void ChargedState()
    {
        isCharged = !isCharged;
        audioSource.PlayOneShot(chargedVirus);
    }

    IEnumerator MoveAround()
    {
        while (isCharged == false && interactable.isSelected == false)
        {
           
            _rigidBody.AddForce(new Vector3(1*Random.Range(-10,10), 1*Random.Range(-10,10), 1*Random.Range(-10,10)));
            yield return new WaitForSeconds(5f);
        }

    }


}
