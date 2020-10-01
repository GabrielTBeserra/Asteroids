using Assets.Scripts.Interface;
using Assets.Scripts.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Objetos
{
    abstract class Player : Vida, Spawnar, Atirar
    {
        public void Atirar()
        {
            throw new NotImplementedException();
        }

        public void Spawn()
        {
            throw new NotImplementedException();
        }
    }
}