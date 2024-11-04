using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEnd : MonoBehaviour
{

    public bool floorDown = false;
    private void OnTriggerEnter(Collider other)
    {
        floorDown = true;
    }
}
