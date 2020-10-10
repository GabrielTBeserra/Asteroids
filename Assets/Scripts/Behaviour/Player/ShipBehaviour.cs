using Assets.Scripts.Interface;
using Assets.Scripts.Objetos;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour, IRigidbody2D, ITransform
{
    /* Identificadores privados */
    private static int ZERO = 0;

    private Transform myTransform;
    private Rigidbody2D rgb2;

    private IMove move;
    private ILimitCamera limitCamera;

    void Awake()
    {
        myTransform = GetComponent<Transform>();
        rgb2 = GetComponent<Rigidbody2D>();
        move = GetComponent<IMove>();
       
        limitCamera = GetComponent<ILimitCamera>();
    }

    void Update()
    {
        rgb2.angularVelocity = ZERO;
    }


    void FixedUpdate()
    {
        limitCamera.updateLimitCamera();
        move.Move();
    }


    public Transform getMyTranform()
    {
        return myTransform;
    }

    public Rigidbody2D get()
    {
        return rgb2;
    }

    public Transform getTransform()
    {
        return myTransform;
    }
}

