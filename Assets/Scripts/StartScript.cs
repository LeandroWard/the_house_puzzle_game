using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    [SerializeField] GameObject behind;
    private void OnTriggerEnter(Collider other)
    {
        behind.SetActive(true);
    }
}
