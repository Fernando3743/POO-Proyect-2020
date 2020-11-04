using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Lugar orillaIzquierda;
    public Lugar orillaDerecha;
    public Lugar miBarca;
    public Individuo robot;
    public Individuo zorro;
    public Individuo conejo;
    public Individuo lechuga;



    private void Update()
    {
        Debug.Log(miBarca.cuantosPasajerosHay());
        moverPersonajes();
    }

    public void moverPersonajes()
    {
        if (Input.GetKeyDown("r"))
        {
            if ((orillaDerecha.estaRobot() && orillaDerecha.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2) || (orillaIzquierda.estaRobot() && orillaIzquierda.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2))
            {
                robot.actualizarVecino("Barca");
                robot.muevete(true);
            }
            else if (miBarca.estaRobot())
            {
                if (orillaDerecha.estaLaBarca())
                {
                    robot.actualizarVecino("Derecha");
                    robot.muevete(true);
                }
                else if(orillaIzquierda.estaLaBarca())
                {
                    robot.actualizarVecino("Izquierda");
                    robot.muevete(true);
                }
            }
        }

        else if (Input.GetKeyDown("c"))
        {
            if ((orillaDerecha.estaConejo() && orillaDerecha.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2) || (orillaIzquierda.estaConejo() && orillaIzquierda.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2))
            {
                conejo.actualizarVecino("Barca");
                conejo.muevete(true);
            }
            else if (miBarca.estaConejo())
            {
                if(orillaDerecha.estaLaBarca())
                {
                    conejo.actualizarVecino("Derecha");
                    conejo.muevete(true);
                }
                else if(orillaIzquierda.estaLaBarca())
                {
                    conejo.actualizarVecino("Izquierda");
                    conejo.muevete(true);
                }
            }
        }

        else if (Input.GetKeyDown("z"))
        {
            if ((orillaDerecha.estaZorro() && orillaDerecha.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2) || (orillaIzquierda.estaZorro() && orillaIzquierda.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2))
            {
                zorro.actualizarVecino("Barca");
                zorro.muevete(true);
            }
            else if (miBarca.estaZorro())
            {
                if (orillaDerecha.estaLaBarca())
                {
                    zorro.actualizarVecino("Derecha");
                    zorro.muevete(true);
                }
                else if(orillaIzquierda.estaLaBarca())
                {
                    zorro.actualizarVecino("Izquierda");
                    zorro.muevete(true);
                }
            }
        }

        else if (Input.GetKeyDown("l"))
        {
            if ((orillaDerecha.estaLechuga() && orillaDerecha.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2) || (orillaIzquierda.estaLechuga() && orillaIzquierda.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2))
            {
                lechuga.actualizarVecino("Barca");
                lechuga.muevete(true);
            }
            else if (miBarca.estaLechuga())
            {
                if (orillaDerecha.estaLaBarca())
                {
                    lechuga.actualizarVecino("Derecha");
                    lechuga.muevete(true);
                }
                else if(orillaIzquierda.estaLaBarca())
                {
                    lechuga.actualizarVecino("Izquierda");
                }
            }
        }

    }
}
