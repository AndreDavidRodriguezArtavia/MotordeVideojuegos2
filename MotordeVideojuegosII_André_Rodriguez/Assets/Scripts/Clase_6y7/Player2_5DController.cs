using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_5DController : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 movement;
    private Camera mainCamera;
    private float originalCameraRotation;
    public bool IsMoving { get { return movement.magnitude > 0.1f; } }

    private void Start()
    {
        mainCamera = Camera.main;
        originalCameraRotation = mainCamera.transform.rotation.eulerAngles.y;     
    }

    private void Update()
    {
        float currentCameraRotation = mainCamera.transform.rotation.eulerAngles.y;
        float cameraRotationDifference = currentCameraRotation - originalCameraRotation;
        originalCameraRotation = currentCameraRotation;

        Vector3 camForward = mainCamera.transform.forward;
        Vector3 camRight = mainCamera.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        movement = camRight * Input.GetAxisRaw("Horizontal") + camForward * Input.GetAxisRaw("Vertical");
        movement = Quaternion.Euler(0, cameraRotationDifference, 0) * movement;

        var animator = GetComponentInChildren<Animator>();
        animator.SetFloat("Magnitud", movement.magnitude);
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }

    public Vector3 GetMovementDirection()
    {
        return movement.normalized;
    }

    public float GetDirectionAngle()
    {
        Vector3 dir = transform.position - mainCamera.transform.position;
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }
}
