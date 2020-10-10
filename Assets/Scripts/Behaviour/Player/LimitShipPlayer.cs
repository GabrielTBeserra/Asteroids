using Assets.Scripts.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitShipPlayer : MonoBehaviour, ILimitCamera
{
    private ITransform myTransform;

    public void Awake()
    {
        myTransform = GetComponent<ITransform>();
    }

    public void updateLimitCamera()
    {
        Vector3 pos = myTransform.getTransform().position;
        float positionX = myTransform.getTransform().position.x;
        float positionY = myTransform.getTransform().position.y;

        if (positionX > GameManager.rightLimit.x)
        {
            pos.x = GameManager.leftLimit.x;
        }
        else if (positionX < GameManager.leftLimit.x)
        {
            pos.x = GameManager.rightLimit.x;
        }
        else if (positionY > GameManager.rightLimit.y)
        {
            pos.y = GameManager.leftLimit.y;
        }
        else if (positionY < GameManager.leftLimit.y)
        {
            pos.y = GameManager.rightLimit.y;
        }

        myTransform.getTransform().position = pos;
    }
}