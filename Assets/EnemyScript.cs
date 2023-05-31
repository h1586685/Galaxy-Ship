using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int speed=-5;
    private Rigidbody2D r2d = null;
    GameObject dir;
    public GameObject increaseBullet;

    // Start is called before the first frame update
    void Start()
    {
        r2d = this.gameObject.GetComponent<Rigidbody2D>();
        r2d.velocity = new Vector2(speed, 0);
        r2d.angularVelocity = Random.Range(-200, 200);
        dir = GameObject.Find("director");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bullet(Clone)" )
        {
            dir.GetComponent<director>().IncreaseScore(1);
            Destroy(gameObject);
            Destroy(collision.gameObject);

            if (Random.Range(1, 10) > 9)
                Instantiate(increaseBullet, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.name == "spaceship" )
        {
            dir.GetComponent<director>().decreasehp();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
