using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rgdb;

    void Start()
    {
        rgdb = GetComponent<Rigidbody2D>();
        rgdb.AddRelativeForce(Vector2.up * 1000);

        Destroy(gameObject, 5.0f);
    }
}
