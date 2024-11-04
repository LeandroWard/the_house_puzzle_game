using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAgain : MonoBehaviour
{
    public GameObject door0;
    [SerializeField] AudioSource doorSound;
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.roomLeft == true)
        {
            Animator doorAnimator = door0.GetComponent<Animator>();
            doorAnimator.SetTrigger("OpenDoor");
            doorSound.Play();
        }
    }

}
