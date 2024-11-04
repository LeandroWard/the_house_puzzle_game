using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool roomLeft = false;
    public bool roomRight = false;
    public bool endGame = false;
    public Inventory inventory;

    private void Start()
    {
       // Application.targetFrameRate = 60;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}