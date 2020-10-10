using Assets.Scripts.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestartShipPlayer : MonoBehaviour, IRestart
{
    private static int ZERO = 0;

    private IRigidbody2D rgb2;
    private IVida vida;
    private IPontos pontos;

    public void Awake()
    {
        rgb2 = GetComponent<IRigidbody2D>();
        vida = GetComponent<IVida>();
    }

    public void isRestart()
    {
        if (vida.isEmpty())
        {
            vida.restart();
            restart();
        }
    }
    void restart()
    {
        pontos.atribuirPontos(ZERO);
        EventController.atribuirPontos(pontos.pontos());
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        gameObject.transform.rotation = new Quaternion();
        rgb2.get().angularVelocity = ZERO;
        rgb2.get().velocity = new Vector2();
    }
}
