using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    public GameObject door;  
    public Light spotlight;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            
            if (door != null)
                door.SetActive(false);

            if (spotlight != null)
            {
              audioSource.Play();
                spotlight.enabled = true;
            }
            
        }
    }
}