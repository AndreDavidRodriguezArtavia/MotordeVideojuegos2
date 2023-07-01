using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 1f;
    public int salud = 20;
    private Transform tower;
    public int damage = 5;
    public GameObject prefabExperience;
    public Transform enemy;
    public GameObject prefabChest;

    private void Start()
    {
        tower = GameObject.FindObjectOfType<Torre>().transform;
    }

    private void Update()
    {
        float step = velocidad * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, tower.position, step);
    }

    public void RecibirDano(int dano)
    {
        salud -= dano;
        if(salud <= 0)
        {
            Morir();
            
            Instantiate(prefabExperience, enemy.position, Quaternion.identity);
            Instantiate(prefabChest, enemy.position, Quaternion.identity);
        }
    }

    private void Morir()
    {
        ManagerJuego juegoManager = FindObjectOfType<ManagerJuego>();
        juegoManager.EnemigoMuerto(this);
        Destroy(gameObject);
    }
     
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Torre>())
        {
            collision.gameObject.GetComponent<Torre>().ReciveDamage(damage);
            
        }
    }
}
