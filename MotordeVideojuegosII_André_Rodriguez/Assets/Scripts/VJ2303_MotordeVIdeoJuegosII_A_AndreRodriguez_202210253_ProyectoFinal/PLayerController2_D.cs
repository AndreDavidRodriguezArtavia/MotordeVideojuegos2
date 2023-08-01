using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController2_D : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);
        transform.position += movement * playerSpeed * Time.deltaTime;

        /*Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if(Physics.Raycast(cameraRay, out floorHit))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            transform.rotation = newRotation;
        }*/
    }
}
