using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 20f;
    public int dano = 5;

    private void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemigo = other.GetComponent<Enemy>();
        if (enemigo != null)
        {
            enemigo.RecibirDano(dano);
        }
        Destroy(gameObject);
    }
}

