using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSFX : MonoBehaviour
{
    public AudioClip[] collisionSounds;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            int randomIndex = Random.Range(0, collisionSounds.Length);
            AudioClip selectedSound = collisionSounds[randomIndex];
            audioSource.PlayOneShot(selectedSound);
        }
    }
}
