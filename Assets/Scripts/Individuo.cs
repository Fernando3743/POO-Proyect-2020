using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Individuo : MonoBehaviour
{
    BarcaMovement miBarca;

    //public string key;

    private bool moverIndividuo = false;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;

    public Transform vecino;
    public Transform izquierda;
    public Transform derecha;
    public Transform barca;
    public GameObject panelOrdenes;


    //private int i = 0;

    private Vector2 actualPos;

    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        if (moverIndividuo)
        {
            moverElIndividuo();
        }
    }

    public void moverElIndividuo()
    {

        if (Vector2.Distance(transform.position, vecino.position) < 0.05f)
        {
            panelOrdenes.SetActive(true);
            moverIndividuo = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, vecino.position, speed * Time.deltaTime);
    }


    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.7f);

        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

        }
        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true); ;
        }
        else if (transform.position.x == actualPos.x)
        {
            animator.SetBool("Run", false);
        }
    }

    public void muevete(bool orden)
    {
        moverIndividuo = orden;
    }

    public void actualizarVecino(string lugar)
    {
        if(lugar=="Barca")
        {
            vecino = barca;
        }
        else if(lugar=="Izquierda")
        {
            vecino = izquierda;
        }
        else if(lugar=="Derecha")
        {
            vecino = derecha;
        }
    }
}
