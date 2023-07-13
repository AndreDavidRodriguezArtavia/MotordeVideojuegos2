using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectable_Item : MonoBehaviour
{
    public Item item;
    public static Action<Item, Vector3> Oncollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Oncollected?.Invoke(item, transform.position);
            Destroy(gameObject);
        }
    }
}
