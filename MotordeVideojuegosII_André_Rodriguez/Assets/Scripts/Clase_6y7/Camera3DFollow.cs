using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3DFollow : MonoBehaviour
{
    public Transform player;
    public Transform cameraParent;
    public Vector3 offset;
    public float rotationSpeed = 5;
    public float mouseSensitivity = 40f;
    private Vector3 rotateInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        cameraParent = transform.parent;
    }

    private void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotateInput = new Vector2(mousex, 0);
    }

    private void LateUpdate()
    {
        PositionPivotRelativeToCenter();
        FollowPlayerXZ();
        PositionCameraRelativeToPivot();
        ApplyPlayerRotation();
        
    }

    private void PositionPivotRelativeToCenter()
    {
        Vector3 playerPosition = player.position;
        playerPosition.y = transform.position.y;
        transform.position = playerPosition;
    }

    private void FollowPlayerXZ()
    {
        Vector3 desireDirection = cameraParent.TransformPoint(offset);
        desireDirection.y = transform.position.y;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desireDirection, 0);
        transform.position = smoothedPosition;
        Vector3 cameraOffset = new Vector3(0, offset.y, -offset.z);
        transform.GetChild(0).localPosition = cameraOffset;
    }

    private void PositionCameraRelativeToPivot()
    {
        Vector3 cameraOffset = new Vector3(0, offset.y, -offset.z);
        transform.GetChild(0).localPosition = Vector3.Lerp(transform.GetChild(0).localPosition, cameraOffset, 0);
    }

    private void ApplyPlayerRotation()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += rotateInput.x * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}
