using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia
{
    public class Asciugatrice : Macchina
    {
        public Asciugatrice() 
        {
            ProgrammiDisponibili = new List<Programma>()
            {
                new Programma(1, "Rapido", 20, 2),
                new Programma(2, "Intenso", 60, 4)
            };
        }
    }
}
