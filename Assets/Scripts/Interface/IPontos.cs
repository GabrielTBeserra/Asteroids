using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPontos 
{
    void addPontos(int pontos);
    void addPonto();

    void removePontos(int pontos);
    void removePonto();
    void atribuirPontos(int pontos);
    int pontos();
}
