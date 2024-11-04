using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TeleportSequenceController : MonoBehaviour
{
    [SerializeField] bool teleport1Activated = false;
    [SerializeField] bool teleport2Activated = false;
    [SerializeField] bool teleport3Activated = false;
    [SerializeField] Collider falseWallCollider;
    [SerializeField] TextMeshPro textElement;
    [SerializeField] Transform objectToMove;    
    [SerializeField] Transform targetPosition;
    [SerializeField] Transform initPosition;
    public AudioSource audioSource;

    private string clue01 = "You see me on maps, and I help you forget.\r\nA sinister creature waits in the shade.\r\nI’m not the way to the rising light.";
    private string clue02 = "A guiding hand that connects all hearts.\r\nWith every choice, I lead the way.\r\nI guide you onward, never out of sight.";
    private string clue03 = "I’m the path you take when the shadows loom.\r\nA direction that whispers of impending doom.\r\nThe choice to retreat in this haunted space?";
    private string clue04 = "But I’m not afraid; I am brave and unique.\r\nMy love awaits just beyond the dark haze.\r\nWhat am I, the call to face your fears?";

    public void ActivateTeleport(int teleportNumber)
    {
        switch (teleportNumber)
        {
            case 1:
                if (!teleport1Activated && !teleport2Activated && !teleport3Activated)
                {
                    teleport1Activated = true;
                    textElement.text = clue02;
                    if (!GameManager.instance.roomLeft)
                    {
                        Invoke("LoadScene1", 0f);
                        GameManager.instance.roomLeft = true;
                    }

                }
                else{
                    teleport1Activated = false;
                    teleport2Activated = false;
                    teleport3Activated = false;
                    falseWallCollider.isTrigger = false;
                    textElement.text = clue01;
                    objectToMove.transform.position = initPosition.position;
                    objectToMove.transform.rotation = initPosition.rotation;
                }
                break;

            case 2:
                if (teleport1Activated && !teleport2Activated && !teleport3Activated)
                {
                    teleport2Activated = true;
                    textElement.text = clue03;
                    if (!GameManager.instance.roomRight)
                    {
                        Invoke("LoadScene2", 0f);
                        GameManager.instance.roomRight = true;
                    }

                }
                else{
                    teleport1Activated = false;
                    teleport2Activated = false;
                    teleport3Activated = false;
                    falseWallCollider.isTrigger = false;
                    textElement.text = clue01;
                    objectToMove.transform.position = initPosition.position;
                    objectToMove.transform.rotation = initPosition.rotation;
                }
                break;

            case 3:
                if (teleport1Activated && teleport2Activated && !teleport3Activated)
                {
                    teleport3Activated = true;
                    Debug.Log("3");
                    falseWallCollider.isTrigger = true;
                    textElement.text = clue04;
                    objectToMove.transform.position = targetPosition.position;
                    objectToMove.transform.rotation = targetPosition.rotation;
                    audioSource.Play();

                }
                else
                {
                    teleport1Activated = false;
                    teleport2Activated = false;
                    teleport3Activated = false;
                    falseWallCollider.isTrigger = false;
                    textElement.text = clue01;
                    objectToMove.transform.position = initPosition.position;
                    objectToMove.transform.rotation = initPosition.rotation;
                }
                break;

            default:
                Debug.Log("");

                break;
        }
    }
    private void LoadScene1() => SceneManager.LoadScene("Sebastian");
    private void LoadScene2() => SceneManager.LoadScene("Santiago");
}