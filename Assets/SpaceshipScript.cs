using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipScript : MonoBehaviour
{
    private Rigidbody2D r2d = null;
    public GameObject bullet;

    int bulletCounter = 1;
    GameObject dir;

    public BulletCounterBar BulletCounterBar;

    Text textBulletCounter;
    // Start is called before the first frame update
    void Start()
    {
        dir = GameObject.Find("director");

        BulletCounterBar.setMaxBullet(3);
        BulletCounterBar.setBullet(bulletCounter);
        textBulletCounter = GameObject.Find("textBulletCounter").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        r2d = this.gameObject.GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.RightArrow))
            r2d.velocity = new Vector2(10, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            r2d.velocity = new Vector2(-10, 0);
        else if (Input.GetKey(KeyCode.UpArrow))
            r2d.velocity = new Vector2(0, 10);
        else if (Input.GetKey(KeyCode.DownArrow))
            r2d.velocity = new Vector2(0, -10);
        else
            r2d.velocity = new Vector2(0, 0);

        if (Input.GetKeyDown(KeyCode.Space)){
            if (bulletCounter == 1)
                Instantiate(bullet, transform.position, Quaternion.identity);
            else if (bulletCounter == 2)
            {
                Vector3 vector1 = new Vector3(transform.position.x
                    , transform.position.y + 0.5f,transform.position.z);
                Vector3 vector2 = new Vector3(transform.position.x
                    , transform.position.y - 0.5f, transform.position.z);
                Instantiate(bullet, vector1, Quaternion.identity);
                Instantiate(bullet, vector2, Quaternion.identity);
            }
            else if (bulletCounter == 3)
            {
                Vector3 vector1 = new Vector3(transform.position.x
                    , transform.position.y + 0.6f, transform.position.z);
                Vector3 vector2 = new Vector3(transform.position.x
                    , transform.position.y - 0.0f, transform.position.z);
                Vector3 vector3 = new Vector3(transform.position.x
                    , transform.position.y - 0.6f, transform.position.z);
                Instantiate(bullet, vector1, Quaternion.identity);
                Instantiate(bullet, vector2, Quaternion.identity);
                Instantiate(bullet, vector3, Quaternion.identity);
            }
        }
        BulletCounterBar.setBullet(bulletCounter);
        textBulletCounter.text = bulletCounter + "/3";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "enemyBullet(Clone)")
        {
            Destroy(collision.gameObject);
            dir.GetComponent<director>().decreasehp();
        }
        if (collision.gameObject.name.StartsWith("increaseBullet"))
        {
            if (bulletCounter < 3)
            {
                bulletCounter++;
                BulletCounterBar.setBullet(bulletCounter);
            }
            Destroy(collision.gameObject);
        }
    }
}
