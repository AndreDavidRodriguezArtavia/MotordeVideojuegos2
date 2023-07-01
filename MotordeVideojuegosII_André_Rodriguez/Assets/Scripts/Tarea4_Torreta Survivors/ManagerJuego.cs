using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerJuego : MonoBehaviour
{
    public GameObject prefabEnemigo;
    public Transform puntoDeSpawn;
    public float tiempoEntreOleadas = 2.0f;
    public List<GameObject> enemigos = new List<GameObject>();
    public int maximosEnemigos;
    public List<GameObject> torres = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(GenerarEnemigos());
    }

    IEnumerator GenerarEnemigos()
    {
        while (true)
        {
            if (enemigos.Count < maximosEnemigos)
            {
                GameObject nuevoEnemigo = Instantiate(prefabEnemigo, puntoDeSpawn.position, Quaternion.identity);
                enemigos.Add(nuevoEnemigo);
            }
            yield return new WaitForSeconds(tiempoEntreOleadas);
        }
    }

    public void EnemigoMuerto(Enemigo enemigo)
    {
        enemigos.Remove(enemigo.gameObject);
    }

    public void DeadTower(Torre torre)
    {
        torres.Remove(torre.gameObject);
    }

}
