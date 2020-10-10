using UnityEngine;
    
    public class Vida : MonoBehaviour, IVida
    {
        private static int ZERO = 0;
        [SerializeField]
        private int vida;
        [SerializeField]
        private int vidaTotal;

        public Vida(int vida)
        {
            vidaTotal = vida;
            this.vida = vida;
        }

        public void aumentarVida(int v)
        {
            if((vida += v) >= vidaTotal)
                vida = vidaTotal;
            else 
                vida += v;
        }

        public void diminuirVida(int v)
        {
            if (vida > ZERO)
            {
                vida -= v;
            }
            else
            {
                vida = ZERO;
            }
        }

        public bool isEmpty()
        {
            return vida <= 0 ? true : false;
        }

        public void restart()
        {
            vida = vidaTotal;
        }

        public int vidaAtual()
        {
            return vida;
        }

        public int vidaMaxima()
        {
            return vidaTotal;
        }
    }

