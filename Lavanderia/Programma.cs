using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia
{
    public class Programma
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public int DurataMinuti { get; set; }
        public int Gettoni { get; set; }
        public int ConsumoDetersivoMl { get; set; }
        public int ConsumoAmmorbidenteMl { get; set; }

        public Programma(int numero, string nome, int durataMinuti, int gettoni, int consumoDetersivoMl = 0, int consumoAmmorbidenteMl = 0)
        {
            Numero = numero;
            Nome = nome;
            DurataMinuti = durataMinuti;
            Gettoni = gettoni;
            ConsumoDetersivoMl = consumoDetersivoMl;
            ConsumoAmmorbidenteMl = consumoAmmorbidenteMl;
        }
    }
}
