using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciate : MonoBehaviour
{
    private Enemigo enemigo;
    public GameObject[] objectsinstantiate;
    void Start()
    {
        
    }

    public void InstantiateObjects()
    {
        Enemigo enemigo = GetComponent<Enemigo>();
        int n = Random.Range(0, objectsinstantiate.Length);
        Instantiate(objectsinstantiate[n], enemigo.enemy.position, Quaternion.identity);
    }
}
