using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider2D c;
        if (!GetComponent<Collider2D>())
        {
            c = gameObject.AddComponent<BoxCollider2D>();
        }
        else
        {
            c = GetComponent<Collider2D>();
        }
        c.isTrigger = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Text txt;
        txt = GameObject.Find("/Canvas/txtScore").GetComponent<Text>();
        GameManager.nScore += 10;
        txt.text = "Score : " + GameManager.nScore;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = false;
        Destroy(gameObject, 0.2f);
    }
}
