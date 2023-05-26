using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private List<Door> doors = new List<Door>();

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
        if (other.CompareTag("Player"))
        {
            foreach (Door door in doors)
            {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Door door in doors)
            {

            }
        }
    }
}
