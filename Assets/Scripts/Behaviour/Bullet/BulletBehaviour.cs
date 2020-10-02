using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rgdb;

    public int Damage { get; set; }
    public string tagName { get; set; }

    void Start()
    {
        rgdb = GetComponent<Rigidbody2D>();
        rgdb.AddRelativeForce(Vector2.up * 500);

        Destroy(gameObject, 5.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals(tagName)) { 
            IColliderWeapon colliderWeapon = collision.GetComponent<IColliderWeapon>();
            if (colliderWeapon != null)
            {
                colliderWeapon.damageWeapon(Damage);
            }
        }
    }


}
