using Assets.Scripts.Interface;
using Assets.Scripts.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Objetos
{
    abstract class Player : Vida , Spawnar, Atirar
    {
        public abstract void Atirar();
        public abstract void Spawn();
    }
}