using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FadeInMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;  
    public Image fadePanelImage;
    [SerializeField] GameManager manager;
    [SerializeField] TextMeshProUGUI textElement;


    private void Start()
    {
        mainMenuPanel.SetActive(false);  
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color color = fadePanelImage.color;
        color.a = 1f; 
        fadePanelImage.color = color;

        for (float t = 0; t < 5f; t += Time.deltaTime)
        {
            color.a = Mathf.Lerp(1f, 0f, t / 5f);
            fadePanelImage.color = color;
            yield return null;
        }

        color.a = 0f;
        fadePanelImage.color = color;
        mainMenuPanel.SetActive(true);
        if(GameManager.instance.endGame == true)
        {
            textElement.text = "The House of Asterion";
        }
        else
        {
            textElement.text = "The House";
        }
        fadePanelImage.gameObject.SetActive(false); 
    }
}