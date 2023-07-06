using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    WATCHING,
    SUSPICION,
    CHASING
}

public class PatrollEnemy : MonoBehaviour
{
    public float speed = 3.0f;
    public float rangeVision = 10f;
    public float angleVision = 45;
    public LayerMask layerObstacles;
    public LayerMask layerPlayer;
    private SimplePlayer player;
    private Vector3 initialAddress;
    private EnemyState state = EnemyState.WATCHING;
    private Coroutine rutineRotation;
    private bool invocationInProcess = false;
    private bool rotationInProcess = true;

    private void Start()
    {
        player = GameObject.FindObjectOfType<SimplePlayer>();
        initialAddress = transform.forward;
        rutineRotation = StartCoroutine(Rotation());
    }

    IEnumerator Rotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            transform.Rotate(0, 90, 0);
            initialAddress = transform.forward;
        }
    }

    private void Update()
    {
        Vector3 playerAddress = (player.transform.position - transform.position).normalized;
        if (Vector3.Angle(initialAddress, playerAddress) < angleVision)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, playerAddress, out hit,rangeVision, layerPlayer | layerObstacles))
            {
                if (hit.collider.GetComponent<SimplePlayer>() != null)
                {
                    if (state != EnemyState.CHASING)
                    {
                        state = EnemyState.SUSPICION;
                        if (rotationInProcess)
                        {
                            StopCoroutine(rutineRotation);
                            rotationInProcess = false;
                        }
                        invocationInProcess = true;
                        Invoke("ConfirmSighting", 5f);
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    }
                }
            }
        }
        else if(state == EnemyState.CHASING && !rotationInProcess)
        {
            state = EnemyState.WATCHING;
            rotationInProcess = true;
            rutineRotation = StartCoroutine(Rotation());
        }
    }

    private void ConfirmSighting()
    {
        Vector3 playerAddress = (player.transform.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, playerAddress, out hit, rangeVision, layerPlayer | layerObstacles))
        {
            if (hit.collider.GetComponent<SimplePlayer>() != null)
            {
                state = EnemyState.CHASING;
            }
        }
        invocationInProcess = false;
    }
}
