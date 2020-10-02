namespace Assets.Scripts.Objetos
{
    abstract class Municao
    {
        public int Quantidade { get; set; }
        public int Maximo { get; set; }

        public void DiminuirMunicao(int q)
        {
            Quantidade -= q;
        }
    }
}
