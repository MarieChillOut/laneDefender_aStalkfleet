using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject bullet;

    [SerializeField] private AudioClip shootClip;

    private Rigidbody2D playerRB;

    private InputAction moveOne;
    private InputAction moveTwo;
    private InputAction shoot;

    private Vector3 offset;
    private Vector3 playerPos;

    private bool isMoving;

    private int speed;

    private float delay;
    private float direction;

    private bool allowFire;
    private bool firing;
    private bool isPaused;

    void Start()
    {
        fire.gameObject.SetActive(false);
        isPaused = false;
        speed = 5;

        delay = 1.6f;

        offset = new Vector3(0.49f, 0.42f, 0.0f);

        isMoving = false;
        allowFire = true;
        firing = false;

        playerRB = player.GetComponent<Rigidbody2D>();

        playerInput.currentActionMap.Enable();
        moveOne = playerInput.currentActionMap.FindAction("upDownOne");
        moveTwo = playerInput.currentActionMap.FindAction("upDownTwo");
        moveOne.started += Move_started;
        moveTwo.started += Move_started;
        moveOne.canceled += Move_Canceled;
        moveTwo.canceled += Move_Canceled;

        shoot = playerInput.currentActionMap.FindAction("Space");
        shoot.started += Shoot_started;
        shoot.canceled += Shoot_canceled;

    }

    private void OnDestroy()
    {
        moveOne.started -= Move_started;
        moveTwo.started -= Move_started;
        moveOne.canceled -= Move_Canceled;
        moveTwo.canceled -= Move_Canceled;

        shoot.started -= Shoot_started;
        shoot.canceled -= Shoot_canceled;
    }

    public void PauseGame()
    {
        isPaused = true;
        isMoving = false;
        firing = false;
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        firing = false;
    }

    private void Shoot_started(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            firing = true;
        }
    }

    IEnumerator Shooting()
    {
        AudioSource.PlayClipAtPoint(shootClip, playerRB.transform.position);
        allowFire = false;
        playerPos = new Vector3(playerRB.position.x, playerRB.position.y, 0f);
        fire.gameObject.SetActive(true);
        Instantiate(bullet, playerPos + offset, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        allowFire = true;
    }

    public void FireEnd()
    {
        fire.gameObject.SetActive(false);
    }


    private void Move_Canceled(InputAction.CallbackContext context)
    {
        isMoving = false;
    }

    private void Move_started(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            isMoving = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isMoving)
        {
            direction = moveOne.ReadValue<float>() + moveTwo.ReadValue<float>();
            playerRB.velocity = new Vector2(0, direction * speed);
        }
        else
        {
            playerRB.velocity = new Vector2(0, 0);
        }

        fire.transform.position = playerRB.transform.position + offset;
    }

    private void Update()
    {
        if (firing && allowFire)
        {
            StartCoroutine(Shooting());
        }
    }
}
