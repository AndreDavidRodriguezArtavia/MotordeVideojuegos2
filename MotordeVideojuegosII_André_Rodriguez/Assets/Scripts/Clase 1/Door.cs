using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openHight = 5f;
    public float openSpeed = 2f;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + new Vector3(0f, openHight, 0f);
        
    }

    private IEnumerator OpenDoorCoroutine()
    {
        float elapsedtime = 0f;
        while (elapsedtime < openSpeed)
        {
            float t = elapsedtime / openSpeed;
            transform.position = Vector3.Lerp(transform.position, targetPosition, t);
            elapsedtime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    private IEnumerator CloseDoorCoroutine()
    {
        float elapsedtime = 0f;
        while (elapsedtime < openSpeed)
        {
            float t = elapsedtime / openSpeed;
            transform.position = Vector3.Lerp(transform.position, initialPosition, t);
            elapsedtime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    public void OpenDoor()
    {
        isOpen = true;
        StopAllCoroutines();
        StartCoroutine(OpenDoorCoroutine());
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            isOpen = false;
            StopAllCoroutines();
            StartCoroutine(CloseDoorCoroutine());

        }
    }

}
