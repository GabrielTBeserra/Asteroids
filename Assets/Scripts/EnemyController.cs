using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rgb;

    private Vector2[] vectorDir = new Vector2[] { Vector2.right, Vector2.up, Vector2.down, Vector2.left };



    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckCamLimits();
    }


    void FixedUpdate()
    {
        rgb.AddForce(vectorDir[Random.Range(0, vectorDir.Length)] * 5);
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
}
