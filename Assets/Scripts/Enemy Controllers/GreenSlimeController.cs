using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlimeController : MonoBehaviour
{
    private Rigidbody2D slimeRB;

    private float speed;
    void Start()
    {
        slimeRB = GetComponent<Rigidbody2D>();

        speed = -2.0f;
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
        slimeRB.velocity = new Vector2(speed, 0);
    }

}
