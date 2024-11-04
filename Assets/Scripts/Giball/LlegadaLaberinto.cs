using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LlegadaLaberinto : MonoBehaviour
{
    [SerializeField] Gimball gimbal;
    [SerializeField] AudioSource doorSound;

    public GameObject door0;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Bola"))
        {
            
            Debug.Log("¡El jugador ha llegado a la meta!");
            other.gameObject.SetActive(false);
            var bola = other.gameObject.GetComponent<PlayerControllerbola>();
            Animator doorAnimator = door0.GetComponent<Animator>();
            
            doorAnimator.SetTrigger("OpenDoor");
            doorSound.Play();

            if (bola != null)
            {
                bola.Interact(FindObjectOfType<PlayerViewController>());
                gimbal.OnExitInteraction();
            }
        }
    }
}
