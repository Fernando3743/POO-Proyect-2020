using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarcaMovement : MonoBehaviour
{

    public int cantidadPasajeros;

    public bool elRobotEsPasajero = false;

    private bool moverLaBarca = false;

    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;

    public Transform[] moveSpots;

    private int i = 0;

    private Vector2 actualPos;

    public GameObject panelOrdenes;

    void Update()
    {
        if(moverLaBarca)
        {
            moverBarca();
        }
    }

    public void moverMiBarca()
    {
        if(elRobotEsPasajero)
        {
            moverLaBarca = true;
            panelOrdenes.SetActive(false);
        }
    }

    public void moverBarca()
    {
        StartCoroutine(CheckEnemyMoving());

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            panelOrdenes.SetActive(true);
            moverLaBarca = false;
            if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
    }

    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Robot") )
        {
            elRobotEsPasajero = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Robot"))
        {
            elRobotEsPasajero = false;
        }

    }
}
