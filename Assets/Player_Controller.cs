using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public float fireRate = 0.2f;
    public float nextFireRate = 0.0f;
    public int healthbar = 100;
    public Text healthText;
    public float speed;
    public bool grounded;
    int jump;
    float x, sx;
    bool ks;
    Animator am;
    Rigidbody2D rb;
    public GameObject hitArea;
    public Slider sliderHp;
    public GameObject MenuController;

    public AudioClip c1;
    AudioSource asource;

    // Start is called before the first frame update
    void Start()
    {
        jump = 0;
        am = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sx = transform.localScale.x;
        asource = GetComponent<AudioSource>();
        sliderHp.maxValue = healthbar;
        sliderHp.value = healthbar;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH: " + healthbar;
        if (healthbar <= 0)
        {
            healthbar = 0;
            am.SetTrigger("Dead");
            MenuController.SetActive(true);
        }

        sliderHp.value = healthbar;
        if (Input.GetKey(KeyCode.L))
        {
            TakeDamage(10);
        }

            if (am.transform.position.y <= -20f)
        {
            Reload();
        }
            am.SetBool("Grounded", true);
        x = Input.GetAxis("Horizontal");
        am.SetFloat("Speed", Abs(x));

        AnimatorStateInfo State = am.GetCurrentAnimatorStateInfo(0);
        if (State.IsName("Jump"))
        {
            asource.clip = c1;
            if (!asource.isPlaying)
            {
                asource.Play();
            }
        }

            if (Input.GetButtonDown("Jump") && jump < 2)
        {
            jump++;
            am.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 20f);
        }
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        if (x > 0)
        {
            transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(-sx, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.P) && Time.time > nextFireRate)
        {
            nextFireRate = Time.time + fireRate;
            am.SetBool("Attack", true);
            Attack();
        }
        else
        {
            am.SetBool("Attack", false);
        }
    }

    void TakeDamage(int damage)
    {
        healthbar = healthbar - damage;
    }

    public void Attack()
    {
        StartCoroutine(DelaySlash());
        //Instantiate(hitArea, transform.position, transform.rotation);
    }

    IEnumerator DelaySlash()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(hitArea, transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "health")
        {
            healthbar = healthbar + 50;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "deathZone")
        {
            healthbar = 0;
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "enemy")
        {
            TakeDamage(20);
        }

        if (other.gameObject.tag == "deadzone")
        {
            TakeDamage(10);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        am.SetBool("Jump", false);
        jump = 0;
    }
    float Abs(float x)
    {
        return x >= 0f ? x : -x;
    }

    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
