using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private GameObject explosion;

    private int speed;
    void Start()
    {
        speed = 10;

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, rb.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

        void Update()
    {
        rb.velocity = new Vector2(2 * speed, 0);
    }
}
