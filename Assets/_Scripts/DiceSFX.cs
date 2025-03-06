using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSFX : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(collisionSound);
    }
}
