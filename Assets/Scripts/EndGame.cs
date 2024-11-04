using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    [SerializeField] AudioSource endSound;
    [SerializeField] AudioSource endSound2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerOne = player.GetComponent<PlayerController>();
            var cameraOne = camera.GetComponent<PlayerViewController>();
            cameraOne.enabled = false;
            playerOne.enabled = false;
            Invoke("LoadMainMenu", 1f);
            GameManager.instance.endGame = true;
            //endSound.Play();
            endSound2.Play();
        }
    }

    private void LoadMainMenu() => SceneManager.LoadScene("Trans");
}