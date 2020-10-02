namespace Assets.Scripts.Objetos
{
    [System.Serializable]
    public class Vida
    {
        public int vidaTotal;
        public int vidaMaxima;

        public Vida(int vida)
        {
            vidaMaxima = vida;
            vidaTotal = vida;
        }

        public void AumentarVida(int v)
        {
            vidaTotal += v;
        }

        public void DiminuirVida(int v)
        {
            vidaTotal -= v;
        }

    }
}
