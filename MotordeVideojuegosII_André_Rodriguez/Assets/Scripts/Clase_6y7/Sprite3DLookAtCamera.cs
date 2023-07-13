using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite3DLookAtCamera : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private Transform player;

    public Color colorNorte;
    public Color colorSur;
    public Color colorEste;
    public Color colorOeste;

    private void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Transform>();
    }

    private void Update()
    {
        RotateSprite();
    }

    private void RotateSprite()
    {
        Vector3 playerDirection = player.transform.forward;
        playerDirection.y = 0;
        float playerRotation = Mathf.Atan2(playerDirection.x, playerDirection.z) * Mathf.Rad2Deg;

        if (player.GetComponentInParent<Player2_5DController>().IsMoving == true)
        {
            playerDirection = player.GetComponentInParent<Player2_5DController>().GetMovementDirection();
            playerRotation = Vector3.Angle(playerDirection, mainCamera.transform.forward);

            Vector3 cross = Vector3.Cross(playerDirection, mainCamera.transform.forward);
            if (cross.y < 0)
            {
                playerRotation = -playerRotation;
            }
        }
        if(playerRotation > 45f && playerRotation <= 135f)
        {
            spriteRenderer.color = colorEste;
        } else if (playerRotation > 135f || playerRotation <= -135f)
        {
            spriteRenderer.color = colorSur;
        }
        else if (playerRotation > -135f && playerRotation <= -145f)
        {
            spriteRenderer.color = colorOeste;
        }
        else
        {
            spriteRenderer.color = colorNorte;
        }

        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
    }
}
