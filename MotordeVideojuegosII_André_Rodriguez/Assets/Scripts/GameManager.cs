using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject manager = new GameObject("GameManager");
                    instance = manager.AddComponent<GameManager>();
                }
                
            }
            return instance;
        }
    }

    private Door currentDoor;

    public void RegistercurrentDoor(Door door)
    {
        currentDoor = door;
    }

    public void UnregistercurrentDoor()
    {
        currentDoor = null;
    }

    private void Awake()
    {
        if ( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
