using Assets.Scripts.Interface;
using UnityEngine;

public class DamageBulletPlayer : MonoBehaviour
{
    [SerializeField]
    protected Transform effects;
    private ITransform myTransform;

    private IVida vida;
    private IRestart restart;


    public void Awake()
    {
        myTransform = GetComponent<ITransform>();
        vida = GetComponent<IVida>();
        restart = GetComponent<IRestart>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))
        {
            IBullet bullet = collision.GetComponent<IBullet>();

            if (!myTransform.getTransform().tag.Equals(bullet.originalTagName()))
            {
                Instantiate(effects, collision.transform.position, Quaternion.identity);
                aplicarDano(bullet.damage());
                Destroy(collision.gameObject);
            }
        }
    }

    void aplicarDano(int damage)
    {
        vida.diminuirVida(damage);
        EventController.atribuirVida(vida.vidaAtual());

        restart.isRestart();
    }

}
