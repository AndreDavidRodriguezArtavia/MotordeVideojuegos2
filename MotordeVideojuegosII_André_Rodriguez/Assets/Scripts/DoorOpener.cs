using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private List<Door> doors = new List<Door>();
    public Door currentDoor;

    public void RegisterDoor(Door door)
    {
        doors.Add(door);
    }

    public void UnregisterDoor(Door door)
    {
        doors.Remove(door);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.currentDoor != null)
        {
            SetCurrentDoor(GameManager.Instance.currentDoor);
        }

        if (other.CompareTag("Player"))
        {
            foreach (Door door in doors)
            {
                if (door != currentDoor)
                {
                    door.CloseDoor();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentDoor != null)
            {
                currentDoor.CloseDoor();
                currentDoor = null;
            }
        }
    }

    public void SetCurrentDoor(Door door)
    {
        currentDoor = door;
    }

}
