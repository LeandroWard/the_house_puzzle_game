using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject player;
    public Camera camera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerOne = player.GetComponent<PlayerController>();
            var cameraOne = camera.GetComponent<PlayerViewController>();
            cameraOne.enabled = false;
            playerOne.enabled = false;
            Invoke("LoadMainMenu", 1f); 
        }
    }

    private void LoadMainMenu() => SceneManager.LoadScene("MainMenu");
}