using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Door currentDoor;

    private void Update()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movehorizontal, 0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E) && currentDoor != null)
        {
            currentDoor.OpenDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Door door = other.GetComponent<Door>();
        if (door != null)
        {
            currentDoor = door;
            GameManager.Instance.RegistercurrentDoor(currentDoor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Door door = other.GetComponent<Door>();
        if (door != null)
        {
            currentDoor = null;
            GameManager.Instance.UnregistercurrentDoor();
        }
    }
}
