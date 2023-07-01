using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public float speed = 1.0f;
    private Transform torre;

    private void Start()
    {
        torre = GameObject.FindObjectOfType<Torre>().transform;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, torre.position, step);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Torre>())
        {
            collision.gameObject.GetComponent<Torre>();
            Destroy(gameObject);
        }     
    }
}
