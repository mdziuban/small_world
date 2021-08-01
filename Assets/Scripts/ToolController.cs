using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolController : MonoBehaviour
{
    [SerializeField] GameObject firePoint;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] GameObject rearFire;
    [SerializeField] GameObject frontFire;
    [SerializeField] InputActionReference triggerPress;
    [SerializeField] InputActionReference primary2dAxis;
    [SerializeField] Rigidbody bullet;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fireWeapon;
    //[SerializeField] AudioClip engineNoise;
    float thrustMultiplier = 10;
    float timeStamp;
    float coolDownInSeconds = .4f;
    float bulletSpeed = 50f;

    private void Start() 
    {
        triggerPress.action.performed += FireLaser;
    }

    private void FireLaser(InputAction.CallbackContext obj)
    {
        if (Time.time > timeStamp)
        {
            timeStamp = Time.time + coolDownInSeconds;
            audioSource.PlayOneShot(fireWeapon);
            Rigidbody spawnedBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            spawnedBullet.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
        }
    }

    private void FixedUpdate() 
    {
        Vector2 thrustAmount = primary2dAxis.action.ReadValue<Vector2>();

        ApplyThrust(thrustAmount.y);
        ThrusterAnimation(thrustAmount.y);
    }


    private void ApplyThrust(float thrustAmount)
    {
            playerRB.AddForce(this.transform.forward * thrustMultiplier * thrustAmount);
            //audioSource.PlayOneShot(engineNoise, thrustAmount);
    }

    private void ThrusterAnimation(float thrustAmount)
    {
        if (thrustAmount > 0)
        {
        
            frontFire.SetActive(true);
            rearFire.SetActive(false);
        }
        else if (thrustAmount < 0)
        {
            frontFire.SetActive(false);
            rearFire.SetActive(true);
        }
        else
        {
            frontFire.SetActive(false);
            rearFire.SetActive(false);
        }
    }


}
