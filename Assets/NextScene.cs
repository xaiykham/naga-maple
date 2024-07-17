using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneName);
    }
}
