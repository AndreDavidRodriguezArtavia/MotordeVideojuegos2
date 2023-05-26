using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Veritcal");

        Vector3 movement = new Vector3(movehorizontal, 0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
