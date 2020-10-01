using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
