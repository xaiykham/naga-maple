using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile_AI : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    //ຕອນຕາຍ
    public GameObject Explode;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("turn"))
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }

        if (other.gameObject.tag == "weaponA")
        {
            Destroy(other.gameObject);
            StartCoroutine(secondDeath(0.2f));
        }

    }

    IEnumerator secondDeath(float sec)
    {
        yield return new WaitForSeconds(sec);
        Instantiate(Explode, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
