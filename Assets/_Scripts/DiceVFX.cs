using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceVFX : MonoBehaviour
{
    public GameObject smokeEffect;
    public float smokeDuration = 0.5f;
    public float smokeSpawn = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dice"))
        {
            Vector3 smokePosition = other.transform.position + Vector3.up * smokeSpawn;
            GameObject effect = Instantiate(smokeEffect, other.transform.position , Quaternion.identity);
            Destroy(effect, smokeDuration);
        }
    }

}
