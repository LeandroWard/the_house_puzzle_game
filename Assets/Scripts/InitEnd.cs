using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEnd : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource.Stop();
        audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.clip = newClip;
        //audioSource.volume = volume;
        audioSource.Play();
        audioSource.loop = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
