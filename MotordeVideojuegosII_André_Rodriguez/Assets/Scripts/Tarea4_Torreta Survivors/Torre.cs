using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public GameObject prefabBala;
    public float velocidadRotacion = 10f;
    public float velocidadBala = 20f;
    public float rango = 10f;
    public float tiempoEntreDisparos = 1f;
    private ManagerJuego juegoManager;
    private GameObject objetivo;
    private bool estaDisparando = false;
    public Transform puntoDeDisparo;
    public float towerSpeed = 5.0f;
    public float healthTower = 20f;
    public int cantExperience;
    

    private void Start()
    {
        juegoManager = FindObjectOfType<ManagerJuego>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");



        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += movement * towerSpeed * Time.deltaTime;

        BuscarObjetivo();
        if (objetivo != null)
        {
            Vector3 direccion = objetivo.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direccion, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, velocidadRotacion * Time.deltaTime);

            if(!estaDisparando)
            {
                estaDisparando = true;
                Disparar();
            }
        }
        else
        {
            estaDisparando = false;
        }
    }

    private void BuscarObjetivo()
    {
        GameObject enemigoMasCercano = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (GameObject enemigo in juegoManager.enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia < distanciaMinima && distancia <= rango)
            {
                enemigoMasCercano = enemigo;
                distanciaMinima = distancia;
            }
        }

        objetivo = enemigoMasCercano;
    }

    private void Disparar()
    {
        StartCoroutine(ManejoDisparo());
    }

    IEnumerator ManejoDisparo()
    {
        GameObject bala = Instantiate(prefabBala, puntoDeDisparo.position, Quaternion.identity);
        Vector3 direccion = (objetivo.transform.position - puntoDeDisparo.position).normalized;
        bala.GetComponent<Rigidbody>().velocity = direccion * velocidadBala;

        yield return new WaitForSeconds(tiempoEntreDisparos);

        estaDisparando = false;
    }

    public void ReciveDamage(int damage)
    {
        healthTower -= damage;
        if (healthTower <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        ManagerJuego juegoManager = FindObjectOfType<ManagerJuego>();
        juegoManager.DeadTower(this);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.GetComponent<Experience>())
        {
            Balas bala = GetComponent<Balas>();
            cantExperience++;
         
            if (cantExperience >= 6)
            {
                healthTower++;
                towerSpeed++;
            }

        }

        

    }

}
