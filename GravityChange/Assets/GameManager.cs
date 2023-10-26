using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private AudioSource Musica;
    private bool IsSceneCero = false;
    private void Awake()
    {
        // Singleton pattern to ensure there is only one instance of GameManager
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 8)
        {
            gameObject.SetActive(false);
        }
        else if (Instance == null)
        {
            gameObject.SetActive(true);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        Musica = GetComponent<AudioSource>();
        Musica.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneName: "Pause");
        }

        if(SceneManager.GetActiveScene().buildIndex == 0 && !IsSceneCero)
        {
            Musica.Stop();
            IsSceneCero =true;
        }
        else if(SceneManager.GetActiveScene().buildIndex != 0 && IsSceneCero)
        {
            Musica.Play();
            IsSceneCero=false;
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
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}