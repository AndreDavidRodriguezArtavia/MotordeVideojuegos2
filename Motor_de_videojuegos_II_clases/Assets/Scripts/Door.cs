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

    private IEnumerable OpenDoorCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < openSpeed)
        {
            float t = elapsedTime / openSpeed;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    private IEnumerable CloseDoorCoroutine()
    {

        float elapsedTime = 0f;
        while (elapsedTime < openSpeed)
        {
            float t = elapsedTime / openSpeed;
            transform.position = Vector3.Lerp(targetPosition, initialPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = initialPosition;
    }

    public void OpenDoor()
    {
        if (isOpen)
        {
            isOpen = false;
            StopAllCoroutines();
            StartCoroutine(OpenDoorCoroutine());
        }
       
    }

    pu
}
