namespace Assets.Scripts.Objetos
{
    [System.Serializable]
    public class Weapon
    {
        public int maxAmmunition;
        public int currentAmmunition;

        public Weapon(int maxAmmunition)
        {
            this.maxAmmunition = maxAmmunition;
            currentAmmunition = maxAmmunition;
        }

        public void removeAmmunition()
        {
            if (currentAmmunition > 0)
            {
                currentAmmunition--;
            }

        }

        public void addAmmunition(int amountAmmunation)
        {
            if (currentAmmunition < maxAmmunition)
            {
                if (currentAmmunition + amountAmmunation > maxAmmunition)
                {
                    currentAmmunition = maxAmmunition;
                }
                else
                {
                    currentAmmunition += amountAmmunation;
                }

            }

        }

        public bool isEmpty()
        {
            return currentAmmunition == 0 ? true : false;
        }


    }
}
