using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBlade : MonoBehaviour
{
    public float speed = 6f;
    public float SecondsDestroy = 0.15f;
    float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Time.time - startTime >= SecondsDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
