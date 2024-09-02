using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void EndFire()
    {
        playerController.FireEnd();
    }
}
