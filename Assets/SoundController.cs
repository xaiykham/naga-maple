using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public Sprite b1;
    public Sprite b2;
    Button b;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.lSound = false;
        b = GameObject.Find("/Canvas/btnSound").GetComponent<Button>();
    }

    public void SoundSwitch()
    {
        GameManager.lSound = !GameManager.lSound;
        AudioListener.pause = GameManager.lSound;
        if (!GameManager.lSound)
        {
            b.image.sprite = b2;
        }
        else
        {
            b.image.sprite = b1;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
