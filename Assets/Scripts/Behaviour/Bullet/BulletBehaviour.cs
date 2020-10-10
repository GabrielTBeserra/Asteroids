using Assets.Scripts.Interface;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IBullet
{
    [SerializeField]
    private Rigidbody2D rgdb;
    [SerializeField]
    protected Transform effects;
    public int Damage { get; set; }
    public string tagName { get; set; }

    void Start()
    {
        rgdb = GetComponent<Rigidbody2D>();
        rgdb.AddRelativeForce(Vector2.up * 500);
        Destroy(gameObject, 5.0f);
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals(tagName)) { 
            IColliderWeapon colliderWeapon = collision.GetComponent<IColliderWeapon>();
            if (colliderWeapon != null)
            {
                Instantiate(effects, transform.position, Quaternion.identity);
                colliderWeapon.damageWeapon(Damage);
                Destroy(gameObject);
            }
        }
    }*/

    public int damage()
    {
        return Damage;
    }

    public string originalTagName()
    {
        return tagName;
    }

    public void originalTagName(string nome)
    {
        tagName = nome;
    }

    public void damage(int damage)
    {
        Damage = damage; ;
    }
}
