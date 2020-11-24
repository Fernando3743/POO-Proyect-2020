using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lugar : MonoBehaviour
{
    public Lugar orillaDrecha;
    public Lugar miBarca;

    public Transform robot;
    public Transform conejo;
    public Transform zorro;
    public Transform lechuga;
    public GameObject imagenGanar;
    public GameObject imagenPerder;
    public GameObject panelOrdenes;
    private bool estaAqui = false;
    private bool ganaste;
    private bool perdiste;
    private bool estaElRobot;
    private bool estaElConejo;
    private bool estaElZorro;
    private bool estaLaLechuga;
    private int cantidadPasajeros;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Robot"))
        {
            estaElRobot = true;
            robot.SetParent(transform);
        }
        if(collision.CompareTag("Conejo"))
        {
            estaElConejo = true;
            conejo.SetParent(transform);
        }
        if (collision.CompareTag("Zorro"))
        {
            estaElZorro = true;
            zorro.SetParent(transform);
        }
        if(collision.CompareTag("Lechuga"))
        {
            estaLaLechuga = true;
            lechuga.SetParent(transform);
        }
        if(collision.CompareTag("Barca"))
        {
            estaAqui = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Robot"))
        {
            estaElRobot = false;
        }
        if (collision.CompareTag("Conejo"))
        {
            estaElConejo = false;
        }
        if (collision.CompareTag("Zorro"))
        {
            estaElZorro = false;
        }
        if (collision.CompareTag("Lechuga"))
        {
            estaLaLechuga = false;
        }
        if (collision.CompareTag("Barca"))
        {
            estaAqui = false; ;
        }
    }

    void Update()
    {
        if (imagenGanar.activeSelf || imagenPerder.activeSelf)
        {
            panelOrdenes.SetActive(false);
        }

        if (!estaElRobot)
        {
            if (estaElConejo && estaElZorro)
            {
                perdiste = true;
            }
            if (estaElConejo && estaLaLechuga)
            {
                perdiste = true;
            }
        }
        if(estaElConejo && estaElRobot && estaElZorro && estaLaLechuga)
        {
            ganaste = true;
        }

        if(perdiste || miBarca.cuantosPasajerosHay()>2)
        {
            imagenPerder.SetActive(true);
            Time.timeScale = 0;
        }
        if(orillaDrecha.ganaste)
        {
            imagenGanar.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public bool estaLaBarca()
    {
        return estaAqui;
    }
    public bool estaRobot()
    {
        return estaElRobot;
    }

    public bool estaZorro()
    {
        return estaElZorro;
    }

    public bool estaConejo()
    {
        return estaElConejo;
    }

    public bool estaLechuga()
    {
        return estaLaLechuga;
    }

    public int cuantosPasajerosHay()
    {
        cantidadPasajeros = 0;
        if(estaElRobot)
        {
            cantidadPasajeros++;
        }
        if (estaElZorro)
        {
            cantidadPasajeros++;
        }
        if(estaElConejo)
        {
            cantidadPasajeros++;
        }
        if (estaLaLechuga)
        {
            cantidadPasajeros++;
        }
        return cantidadPasajeros;
    }
}
