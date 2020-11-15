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
    public GameObject panelOrdenes;
    public BarcaMovement laBarca;

    private bool esPasajero(Lugar unLugar,Individuo unIndividuo)
    {
        if(unIndividuo==robot)
        {
            return unLugar.estaRobot();
        }
        else if (unIndividuo == zorro)
        {
            return unLugar.estaZorro();
        }
        else if (unIndividuo == conejo)
        {
            return unLugar.estaConejo();
        }
        else if (unIndividuo == lechuga)
        {
            return unLugar.estaLechuga();
        }
        return false;
    }

    private void movement(Individuo unIndividuo)
    {
        if ((esPasajero(orillaDerecha,unIndividuo) && orillaDerecha.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2) || (esPasajero(orillaIzquierda, unIndividuo) && orillaIzquierda.estaLaBarca() && miBarca.cuantosPasajerosHay() < 2))
        {
            panelOrdenes.SetActive(false);
            unIndividuo.actualizarVecino("Barca");
            unIndividuo.muevete(true);
        }
        else if (esPasajero(miBarca,unIndividuo))
        {
            if (orillaDerecha.estaLaBarca())
            {
                panelOrdenes.SetActive(false);
                unIndividuo.actualizarVecino("Derecha");
                unIndividuo.muevete(true);
            }
            else if (orillaIzquierda.estaLaBarca())
            {
                panelOrdenes.SetActive(false);
                unIndividuo.actualizarVecino("Izquierda");
                unIndividuo.muevete(true);
            }
        }

    }


    public void moverRobot()
    {
        movement(robot);
    }

    public void moverZorro()
    {
        movement( zorro);
    }

    public void moverConejo()
    {
        movement( conejo);
    }

    public void moverLechuga()
    {
        movement( lechuga);
    }

    public void moverBarca()
    {
        laBarca.moverMiBarca();
    }
}
