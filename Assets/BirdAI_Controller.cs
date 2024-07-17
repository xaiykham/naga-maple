using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI_Controller : MonoBehaviour
{
    public Transform target, player; // ແມ່ນຕົວທີ່ ສັດຕູ ຕາມ Targrt ແມ່ນ ທິດທາງ player ເປົ້າໝາຍ
    public GameObject Explode, enemyBullet, Gun;
    public float followTime; //ແມ່ນ ໄລຍະເວລາ ການຕາມ
    public int flip = 0; // ແມ່ນການໝຸນ ລະຫວ່າງ 180 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
        if (player.position.x > transform.position.x)
        {
            flip = 180;
        }
        else
        {
            flip = 0;
        }
        transform.Translate(Vector2.right * 4f * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, flip);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "follow")
        {
            Instantiate(enemyBullet, Gun.transform.position, Gun.transform.rotation);
            target.transform.position = new Vector3(Random.Range(37f, 57f), 0f, 0f);
        }
        if (other.gameObject.tag == "weaponA")
        {
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
