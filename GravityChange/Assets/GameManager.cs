using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private ControlPersonaje Player;

    private void Awake()
    {
        // Singleton pattern to ensure there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Player = ControlPersonaje.Instance;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(Player);
            SceneManager.LoadScene(sceneName: "Pause");
        }
    }
    public void canviEscena(int escena)
    {
        if (escena == 0)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(escena);
        }
    }
}