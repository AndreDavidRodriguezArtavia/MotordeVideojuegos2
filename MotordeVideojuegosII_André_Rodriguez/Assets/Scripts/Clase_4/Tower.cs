using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject prefabBala;
    public float velocidadRotation = 10f;
    public float velocidadBala = 20f;
    public float rango = 10f;
    public float tiempoEntreDisparos = 1f;
    private JuegoManager juegoManager;
    private GameObject objetivo;
    private bool estaDisparando = false;
    public Transform puntoDeDisparo;

    private void Start()
    {
        juegoManager = FindObjectOfType<JuegoManager>();
    }

    private void Update()
    {

        BuscarObjetivo();
        if (objetivo != null)
        {
            Vector3 direccion = objetivo.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direccion, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, velocidadRotation * Time.deltaTime);

            if (!estaDisparando)
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
            if(distancia < distanciaMinima && distancia <= rango)
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

    IEnumerator ManejoDisparo ()
    {
        GameObject bala = Instantiate(prefabBala, puntoDeDisparo.position, Quaternion.identity);
        Vector3 direccion = (objetivo.transform.position - puntoDeDisparo.position).normalized;
        bala.GetComponent<Rigidbody>().velocity = direccion * velocidadBala;

        yield return new WaitForSeconds(tiempoEntreDisparos);

        estaDisparando = false;
    }
}
