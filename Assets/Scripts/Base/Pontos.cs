using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public class Pontos: MonoBehaviour , IPontos
    {
        private static int ZERO;
        [SerializeField]
        private int pontosAtuais;
        public Pontos()
        {
            pontosAtuais = 0;
        }

        public void addPonto()
        {
            pontosAtuais++;
        }

        public void addPontos(int pontos)
        {
            this.pontosAtuais += pontos;
        }

        public void atribuirPontos(int pontos)
        {
            this.pontosAtuais = pontos;
        }

        public void removePonto()
        {
            pontosAtuais--;
            pontosZero();
        }

        public void removePontos(int pontos)
        {
            this.pontosAtuais -= pontos;
            pontosZero();
        }

        public int pontos()
        {
            return pontosAtuais;
        }

        public void pontosZero()
        {
            if (pontosAtuais < ZERO)
            {
                pontosAtuais = ZERO;
            }
        }
    }

