using Assets.Scripts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Objetos
{
    abstract class Inimigo : Vida, Spawnar, Atirar
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
