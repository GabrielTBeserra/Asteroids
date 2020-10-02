using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventController 
{
    public delegate void eventHudManager(int value);

    public static eventHudManager atribuirPontos;
    public static eventHudManager atribuirVida;
    public static eventHudManager atribuirAmmunition;
}
