using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShip : MonoBehaviour
{
    GameObject dir;
    public GameObject bullet;
    public float attackspeed = 2.5f;
    Animator animator;

    private GameObject player = null;
    Vector3 direction;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 2.0f;

    int hp = 3;

    public hpbar hpbar;
    public GameObject increaseBullet;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("attack", 0, attackspeed);
        rb = this.GetComponent<Rigidbody2D>();
        if (player == null)
            player = GameObject.Find("spaceship");
        dir = GameObject.Find("director");

        this.animator = GetComponent<Animator>();

        hpbar.setMaxHealth(3);
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();
        movement = direction;

        hpbar.setHealth(hp);
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position +
            (dir * moveSpeed * Time.deltaTime));
    }

    void attack()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            animator.Play("gethurt",0,0f);
            Destroy(collision.gameObject);
            hp--;
            if (hp == 0)
            {
                dir.GetComponent<director>().IncreaseScore(3);
                Destroy(gameObject);

                if (Random.Range(1.0f, 10.0f) > 9.2)
                Instantiate(increaseBullet, transform.position, Quaternion.identity);
            }
        }
        if (collision.gameObject.name == "spaceship")
        {
            dir.GetComponent<director>().decreasehp();
            Destroy(gameObject);
        }
    }
}
