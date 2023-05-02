using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia
{
    public class Lavanderia
    {
        public Dictionary<int, Macchina> Macchine { get; set; }

        public Lavanderia() 
        {
            Macchine = new Dictionary<int, Macchina>()
            {
                { 1, new Lavatrice() },
                { 2, new Lavatrice() },
                { 3, new Lavatrice() },
                { 4, new Asciugatrice() },
                { 5, new Asciugatrice() },
            };
        }
    }
}
