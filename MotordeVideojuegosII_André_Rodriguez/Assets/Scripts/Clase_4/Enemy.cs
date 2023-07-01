using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad = 1f;
    public int salud = 20;
    private Transform torre;

    private void Start()
    {
        torre = GameObject.FindObjectOfType<Tower>().transform;
    }

    private void Update()
    {
        float step  = velocidad * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, torre.position, step);
    }

    public void RecibirDano(int dano)
    {
        salud -= dano;
        if (salud <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        JuegoManager juegoManager = FindObjectOfType<JuegoManager>();
        juegoManager.EnemigoMuerto(this);
        Destroy(gameObject);
    }
}
