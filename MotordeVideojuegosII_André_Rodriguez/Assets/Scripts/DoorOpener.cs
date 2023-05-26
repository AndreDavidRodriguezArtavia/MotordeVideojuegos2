using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private List<Door> doors = new List<Door>();
    private Door currentDoor;

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
        if(GameManager.Instance.cur)
        if(GameManager.Instance.cur)
        if (other.CompareTag("Player"))
        {
            foreach (Door door in doors)
            {
                if (door != currentDoor)
                {
                    door.CloseDoor();
                }
            }
            /*if (currentDoor != null)
            {
                currentDoor.OpenDoor();
            }*/
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

    public void setCurrentDoor(Door door)
    {
        currentDoor = door;
    }

}
