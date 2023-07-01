using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Torre>())
        {
            collision.gameObject.GetComponent<Torre>();
            Destroy(gameObject);
            Time.timeScale = 0;
        }

    }
}
