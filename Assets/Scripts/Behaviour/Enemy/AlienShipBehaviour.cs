using Assets.Scripts.Interface;
using Assets.Scripts.Objetos;
using UnityEngine;

public class AlienShipBehaviour : Entity, IColliderWeapon, IShoot
{
    [SerializeField]
    private Transform effects;
    private Rigidbody2D rgb;

    private Vector2[] vectorDir = new Vector2[] {
        Vector2.right,
        Vector2.up,
        Vector2.down,
        Vector2.left
    };

    [SerializeField]
    private Transform shooter;


    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    float shootInterval;

    private ShipBehaviour ship;

    float lastShootTime;
    float timeShootCounter;
    float lastMovimentTime;
    float timeMovimentTime;
    float movimentInterval = 1;

    [SerializeField]
    float velocity;


    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        rgb.AddForce(vectorDir[Random.Range(0, vectorDir.Length)] * velocity);
        ship = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipBehaviour>();
    }

    void Update()
    {
        CheckCamLimits();
    }


    void FixedUpdate()
    {
        timeShootCounter += Time.deltaTime;
        timeMovimentTime += Time.deltaTime;

        if ((lastShootTime + shootInterval) < timeShootCounter)
        {
            shoot();
            timeShootCounter = 0;
        }

        if ((lastMovimentTime + movimentInterval) < timeMovimentTime)
        {
            rgb.velocity = vectorDir[Random.Range(0, vectorDir.Length)] * velocity;
            timeMovimentTime = 0;
        }
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


    public void damageWeapon(int damage)
    {
        EventController.atribuirPontos(ship.addPoints(pontos.pontos));
        GameManager.gameEnemies--;
        Destroy(gameObject);
    }

    public void shoot()
    {
        float angle = Mathf.Atan2(ship.getMyTranform().position.y - transform.position.y, ship.getMyTranform().position.x - transform.position.x) * Mathf.Rad2Deg - 90;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        shooter.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1000);

        GameObject bulletGo = Instantiate(bulletPrefab, transform.position, shooter.rotation);
        BulletBehaviour bulletBehaviour = bulletGo.GetComponent<BulletBehaviour>();
        bulletBehaviour.Damage = 1;
        bulletBehaviour.tagName = "Enemy";
    }
}
