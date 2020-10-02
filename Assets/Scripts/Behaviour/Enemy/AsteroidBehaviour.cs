using Assets.Scripts.Objetos;
using UnityEngine;

public class AsteroidBehaviour : AsteroidBaseBehaviour, IColliderWeapon
{
    Rigidbody2D rgb2;

    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        rgb2.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }


    public void damageWeapon(int damage)
    {
        vida.diminuirVida(damage);
        if (vida.isEmpty())
        {
            EventController.atribuirPontos(pontos.pontos);
            destroyAsteroid();
        }
    }
}
