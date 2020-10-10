using Assets.Scripts.Interface;
using Assets.Scripts.Objetos;
using UnityEngine;

public class WeaponShipPlayer : MonoBehaviour, IWeapon
{
    private static string NAME_TAG = "Player";
    private static string AMMO = "Ammo";
    private static int DAMAGE_ONE = 1;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firespotTransform;
    [SerializeField] private Weapon weapon;

    public void addAmmunition(int amountAmmunation)
    {
        weapon.addAmmunition(amountAmmunation);
    }

    public int getCurrentAmmunition()
    {
        return weapon.currentAmmunition;
    }

    public bool isEmptyAmmunition()
    {
        return weapon.isEmpty();
    }

    public void removeAmmunition()
    {
        weapon.removeAmmunition();
    }

    public void shoot()
    {
        if (!weapon.isEmpty())
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firespotTransform.position, firespotTransform.rotation);
            IBullet bulletController = bulletGo.GetComponent<IBullet>();

            bulletController.damage(DAMAGE_ONE);
            bulletController.originalTagName(NAME_TAG);

            weapon.removeAmmunition();
            EventController.atribuirAmmunition(weapon.currentAmmunition);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag(AMMO))
        {
            weapon.addAmmunition(col.gameObject.GetComponent<IAmmo>().ammo());
            EventController.atribuirAmmunition(weapon.currentAmmunition);
            Destroy(col.gameObject);
        }
    }
}
