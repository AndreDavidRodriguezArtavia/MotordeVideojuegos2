using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite3DLookAtCamera : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private Transform player;
    private Vector3 lastPlayerDirection;

    private void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Transform>();
        lastPlayerDirection = Vector3.forward;
    }

    private void Update()
    {
        RotateSprite();
    }

    private void RotateSprite()
    {
        Vector3 playerDirection = player.transform.forward;
        float playerRotation;

        if (player.GetComponentInParent<Player2_5DController>().IsMoving == true)
        {
            playerDirection = player.GetComponentInParent<Player2_5DController>().GetMovementDirection();
            lastPlayerDirection = playerDirection;


        }
        else
        {
            playerDirection = lastPlayerDirection;
        }

        Vector3 relativeDr = mainCamera.transform.InverseTransformDirection(playerDirection);
        playerRotation = Mathf.Atan2(relativeDr.x, relativeDr.z) * Mathf.Rad2Deg;

        playerRotation += 90f;
        var animator = GetComponent<Animator>();
        animator.SetFloat("DirectionX", -Mathf.Cos(playerRotation + Mathf.Rad2Deg));
        animator.SetFloat("DirectionZ", Mathf.Sin(playerRotation + Mathf.Rad2Deg));

        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
    }
}
