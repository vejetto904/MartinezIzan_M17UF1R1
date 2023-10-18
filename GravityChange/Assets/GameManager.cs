using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int ActualScene;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            ActualScene = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("ActualScene", ActualScene);
            PlayerPrefs.Save();

            SceneManager.LoadScene(sceneName:"Pause");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameObject LoadPJ = GameObject.Find("LoadPJ");
            if (LoadPJ != null)
            {
                Vector3 Posiciones = LoadPJ.transform.position;
                Player.position = new Vector3(Posiciones.x,Player.position.y,Player.position.z);

            }
            DontDestroyOnLoad(gameObject);
        }

        if (collision.gameObject.CompareTag("ReturnLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            GameObject LoadPJ = GameObject.Find("Return");
            if (LoadPJ != null)
            {
                Vector3 Posiciones = LoadPJ.transform.position;
                Player.position = new Vector3(Posiciones.x, Player.position.y, Player.position.z);
            }
            if((SceneManager.GetActiveScene().buildIndex-1) == 2)
            {
                Destroy(gameObject);
            }
            
            //gameObject.transform.Translate(transform.position);
        }
        if (collision.gameObject.CompareTag("Pinchos"))
        {
            // El jugador ha tocado los pinchos, reinicia la escena
            Destroy(gameObject);
            SceneManager.LoadScene(0);
            
        }
    }
}
