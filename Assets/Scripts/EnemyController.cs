using UnityEngine;

public class EnemyController : MonoBehaviour
{
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

    float lastShootTime;
    float timeShootCounter;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica os limites da camera para teleportar para o outro lado
        CheckCamLimits();
        // Mantem a nave sempre 'reta' mesmo se ouver colisao
        transform.rotation = Quaternion.identity;
        // Adiciona uma forca aleatoria em um direcao aleatoria
        rgb.AddForce(vectorDir[Random.Range(0, vectorDir.Length)] * 5);
    }


    void FixedUpdate()
    {
        timeShootCounter += Time.deltaTime;

        if ((lastShootTime + shootInterval) < timeShootCounter)
        {
            Shot();
            timeShootCounter = 0;
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

    void Shot()
    {
        Vector3 targetDirection = ShipController.pos - transform.position;
        Vector3 toRotate = Vector3.RotateTowards(transform.forward, targetDirection, 1.0f, 0.0f);

        Debug.DrawRay(shooter.position, toRotate, Color.red);

        float angle = Mathf.Atan2(ShipController.pos.y - transform.position.y, ShipController.pos.x - transform.position.x) * Mathf.Rad2Deg - 90;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        shooter.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1000);

        Instantiate(bulletPrefab, transform.position, shooter.rotation);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.gameEnemies--;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.gameEnemies--;
        Destroy(gameObject);
    }
}
