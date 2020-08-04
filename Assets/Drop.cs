using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drop : MonoBehaviour
{
    private Scene _activeScene;
    private void Start()
    {
        _activeScene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(_activeScene.name);
    }
}
