using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    Rigidbody2D rgb2;

    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        rgb2.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    void Update()
    {
        TeleportOnCameraLimit();
    }

    void TeleportOnCameraLimit()
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroi o asteroid caso uma 'Bullet' toque nele
        if (collision.CompareTag("Bullet"))
        {
            GameManager.gameAsteroids--;
            Destroy(gameObject);
        }
    }
}
