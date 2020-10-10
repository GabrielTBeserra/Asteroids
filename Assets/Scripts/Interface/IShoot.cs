using Assets.Scripts.Objetos;

namespace Assets.Scripts.Interface
{
    public interface IWeapon
    {
        void shoot();
        void removeAmmunition();
        void addAmmunition(int amountAmmunation);
        bool isEmptyAmmunition();
        int getCurrentAmmunition();
    }
}
