using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody2D r2d = null;
    // Start is called before the first frame update
    void Start()
    {
        r2d = this.gameObject.GetComponent<Rigidbody2D>();
        r2d.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
