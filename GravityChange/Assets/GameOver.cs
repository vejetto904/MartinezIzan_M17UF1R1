using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(2);
    }
    public void exit()
    {
        Application.Quit();
    }
}
