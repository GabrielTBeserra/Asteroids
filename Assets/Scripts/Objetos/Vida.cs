namespace Assets.Scripts.Objetos
{
    class Vida
    {
        public int VidaTotal { get; set; }
        public int VidaMaxima;

        public void AumentarVida(int v)
        {
            VidaTotal += v;
        }

        public void DiminuirVida(int v)
        {
            VidaTotal -= v;
        }

    }
}
