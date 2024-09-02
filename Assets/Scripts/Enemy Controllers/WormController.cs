using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private ScoreCalculator sC;
    private Rigidbody2D wormRB;

    [SerializeField] private float speed;

    [SerializeField] private int lives;
    [SerializeField] private int score;

    [SerializeField] private bool isHit;

    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip hitClip;
    void Start()
    {
        animator.SetBool("IsHit", false);
        animator.SetBool("IsDead", false);
        sC = FindObjectOfType<ScoreCalculator>();
        wormRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(hitClip, wormRB.transform.position);
            animator.SetBool("IsHit", true);
            isHit = true;
            lives--;
            if (lives <= 0)
            {
                AudioSource.PlayClipAtPoint(deathClip, wormRB.transform.position);
                sC.AddScore(score);
                animator.SetBool("IsDead", true);
            }
        }

        if (collision.gameObject.tag == "Boundary" || collision.gameObject.tag == "Player")
        {
            sC.LifeDown();
            Destroy(gameObject);
        }
    }

    public void DeathEvent()
    {
        Destroy(gameObject);
    }

    public void EndHitEvent()
    {
        animator.SetBool("IsHit", false);
        isHit = false;
    }

    private void Update()
    {
        if (!sC.IsGamePaused() && !isHit)
        {
            wormRB.velocity = new Vector2(speed, 0);
        }
        else
        {
            wormRB.velocity = Vector2.zero;
        }
    }


}
