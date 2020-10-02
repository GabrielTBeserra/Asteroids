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

        public void aumentarVida(int v)
        {
            vidaTotal += v;
        }

        public void diminuirVida(int v)
        {
            if (vidaTotal > 0)
            {
                vidaTotal -= v;
            }
            else
            {
                vidaTotal = 0;
            }
        }

        public bool isEmpty()
        {
            return vidaTotal <= 0 ? true : false;
        }
    }
}
