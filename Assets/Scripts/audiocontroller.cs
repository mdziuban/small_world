using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{
    private static audiocontroller instance = null;
    private AudioSource _audio;

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return; 
        Destroy(gameObject);
    }

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }
}
