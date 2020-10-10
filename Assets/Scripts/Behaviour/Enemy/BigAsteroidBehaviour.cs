using Assets.Scripts.Objetos;
using UnityEngine;

public class BigAsteroidBehaviour : AsteroidBaseBehaviour, IColliderWeapon

{
    [SerializeField]
    private GameObject asteroidPrefab;

    Rigidbody2D rg;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    public void damageWeapon(int damage)
    {
        vida.diminuirVida(damage);
        if (vida.isEmpty())
        {
            EventController.atribuirPontos(pontos.pontos());
            destroyAsteroid();
            for (int i = 0; i < 3; i++)
            {
                Instantiate(asteroidPrefab, gameObject.transform.position , gameObject.transform.rotation);
            }
        }
    }
}
