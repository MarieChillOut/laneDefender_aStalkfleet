using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : MonoBehaviour
{
    private Rigidbody2D snailRB;

    private float speed;
    void Start()
    {
        snailRB = GetComponent<Rigidbody2D>();

        speed = -1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        snailRB.velocity = new Vector2(speed, 0);
    }

}
