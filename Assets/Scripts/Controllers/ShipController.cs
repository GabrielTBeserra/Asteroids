using Assets.Scripts.Interface;
using Assets.Scripts.Objetos;
using UnityEngine;

public class ShipController : Entity, Atirar
{
    [SerializeField]
    private int speed;
    //    [SerializeField]
    //      private HUDManager hud;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firespotTransform;
    private Transform myTransform;
    [SerializeField]
    private Weapon weapon;
    private Rigidbody2D rgb2;

    [SerializeField]
    public float rotationSpeed;


    void Start()
    {
        myTransform = GetComponent<Transform>();
        rgb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rgb2.angularVelocity = 0;
    }


    public Transform getMyTranform()
    {
        return myTransform;
    }

    public int addPoints(int points)
    {
        pontos.pontos += points;
        return pontos.pontos;
    }

    public void reset()
    {
        pontos.pontos = 0;
    }

    void FixedUpdate()
    {
        CheckCamLimits();
        Mover();
    }

    void CheckCamLimits()
    {
        Vector3 pos = transform.position;

        if (transform.position.x > GameManager.rightLimit.x)
        {
            pos.x = GameManager.leftLimit.x;
        }
        else if (transform.position.x < GameManager.leftLimit.x)
        {
            pos.x = GameManager.rightLimit.x;
        }
        else if (transform.position.y > GameManager.rightLimit.y)
        {
            pos.y = GameManager.leftLimit.y;
        }
        else if (transform.position.y < GameManager.leftLimit.y)
        {
            pos.y = GameManager.rightLimit.y;
        }

        transform.position = pos;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ammo"))
        {
            weapon.addAmmunition(5);
            // hud.Bullets(weapon.currentAmmunition);

            HUDManager.atribuirAmmunition(weapon.currentAmmunition);
            Destroy(col.gameObject);
        }
        else
        {
            vida.DiminuirVida(1);
            if (vida.vidaTotal == 0)
            {
                Respawn();

                vida.vidaTotal = 3;
            }
            HUDManager.atribuirVida(vida.vidaTotal);
            //hud.LifeBar(vida.vidaTotal);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        vida.DiminuirVida(1);
        if (vida.vidaTotal == 0)
        {
            Respawn();

            vida.vidaTotal = 3;
        }
        HUDManager.atribuirVida(vida.vidaTotal);
        //hud.LifeBar(vida.vidaTotal);
    }

    void Respawn()
    {
        //hud.Score(0);
        reset();
        HUDManager.atribuirPontos(pontos.pontos);
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        gameObject.transform.rotation = new Quaternion();
        rgb2.angularVelocity = 0;
        rgb2.velocity = new Vector2();
    }

    public void Mover()
    {
        float h = rotationSpeed * Input.GetAxisRaw("Horizontal");
        float v = rotationSpeed * Input.GetAxisRaw("Vertical");

        transform.Rotate(-Vector3.forward * h * rotationSpeed);
        rgb2.AddRelativeForce(Vector3.up * v * speed);
    }

    public void Atirar()
    {
        if (!weapon.isEmpty())
        {
            GameObject gm = Instantiate(bulletPrefab, firespotTransform.position, firespotTransform.rotation);
            gm.tag = "Bullet";
            weapon.removeAmmunition();
            HUDManager.atribuirAmmunition(weapon.currentAmmunition);
           //hud.Bullets(weapon.currentAmmunition);
        }
    }
}
