using Assets.Scripts.Objetos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBaseBehaviour : Entity
{
    
    void Update()
    {
        TeleportOnCameraLimit();
    }

    protected void TeleportOnCameraLimit()
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

    protected void destroyAsteroid()
    {
        GameManager.gameAsteroids--;
        Destroy(gameObject);
    }
}
