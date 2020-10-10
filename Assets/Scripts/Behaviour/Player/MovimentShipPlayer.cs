using Assets.Scripts.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentShipPlayer : MonoBehaviour, IMove
{
    [SerializeField] private float speed;
    [SerializeField] public float rotationSpeed;
    private IRigidbody2D rgb2;

    public void Awake()
    {
        rgb2 = GetComponent<IRigidbody2D>();
    }

    public void Move()
    {
        float h = rotationSpeed * Input.GetAxisRaw("Horizontal");
        float v = rotationSpeed * Input.GetAxisRaw("Vertical");

        transform.Rotate(-Vector3.forward * h * rotationSpeed);
        rgb2.get().AddRelativeForce(Vector3.up * v * speed);
    }
}
