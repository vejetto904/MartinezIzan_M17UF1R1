using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    public Transform _transform;
    public GameObject spawnPointOne;
    public GameObject spawnPointTwo;
    private bool _isSpawned = true;

    private void OnLevelWasLoaded(int level)
    {
        _transform = GetComponent<Transform>();

        spawnPointOne = GameObject.Find("EmptyOne");
        spawnPointTwo = GameObject.Find("EmptyTwo");

        if (_isSpawned == true) _transform.position = spawnPointOne.transform.position;
        else _transform.position = spawnPointTwo.transform.position;

        Debug.Log(_isSpawned);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("NextLevel")) _isSpawned = true;
        else if(collision.gameObject.CompareTag("ReturnLevel")) _isSpawned = false;
    }
}
