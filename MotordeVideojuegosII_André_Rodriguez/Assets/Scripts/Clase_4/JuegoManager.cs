using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoManager : MonoBehaviour
{
    public GameObject prefabEnemigo;
    public Transform puntoDeSpawn;
    public float tiempoEntreOleadas = 2.0F;
    public List<GameObject> enemigos = new List<GameObject>();
    public int maximosEnmigos;

    private void Start()
    {
        
    }

    IEnumerator GenerarEnemigo()
    {
        while(true)
        {
            if(enemigos.Count < maximosEnmigos)
            {
                GameObject nuevoEnemigo = Instantiate(prefabEnemigo, puntoDeSpawn.position, Quaternion.identity);
                enemigos.Add(nuevoEnemigo);
            }
            yield return new WaitForSeconds(tiempoEntreOleadas);
        }
    }

    public void EnemigoMuerto(Enemy enemigo)
    {
        enemigos.Remove(enemigo.gameObject);
    }
}
