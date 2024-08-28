using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    private ScoreCalculator sC;
    private Rigidbody2D wormRB;

    [SerializeField] private float speed;

    [SerializeField] private int lives;

    [SerializeField] private int score;
    void Start()
    {
        sC = FindObjectOfType<ScoreCalculator>();
        wormRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            lives--;
            if (lives <= 0)
            {
                sC.AddScore(score);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        wormRB.velocity = new Vector2(speed, 0);
    }


}
