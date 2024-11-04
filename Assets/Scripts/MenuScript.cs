using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditPanel;  

    
    public void PlayGame()
    {
        SceneManager.LoadScene("Leandro");
    }

    
    public void ShowCredits()
    {
        creditPanel.SetActive(true);  
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void HideCredits()
    {
        creditPanel.SetActive(false);
    }
}
