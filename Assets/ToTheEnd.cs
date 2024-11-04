using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ToTheEnd : MonoBehaviour
{
    
    [SerializeField] GameObject floor;
    [SerializeField] EnableEnd trap;
    [SerializeField] GameObject blackHole;

    private void OnTriggerEnter(Collider other)
    {
        if (trap.floorDown == true)
        {
            Destroy(floor);
            blackHole.SetActive(true);
            Invoke("LoadMainMenu", 4f);
           
        }
    }

    private void LoadMainMenu() => SceneManager.LoadScene("Final");
}
