using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia
{
    public class Macchina
    {
        public bool Aperta { get; set; }
        public bool InFunzione { get; set; }
        public int GettoniPresenti { get; set; }
        public int TempoRimanenteFineProgrammaMinuti { get; set; }
        public Programma ?ProgrammaSelezionato { get; set; }
        public List<Programma> ProgrammiDisponibili { get; set; }

        public Macchina() 
        {
            Aperta = Helper.ReturnRandomNumber(0, 1) != 0;
            InFunzione = false;
            GettoniPresenti = Helper.ReturnRandomNumber(0, 15);
        }

        public void ApriSportello()
        {
            if(InFunzione)
                Console.WriteLine("Impossibile aprire lo sportello mentre la macchina è in funzione");
            else
                Aperta = true;
        }
        public void ChiudiSportello() => Aperta = false;

        public void InserisciGettoni(int gettoni)
        {
            if(gettoni <= 0)
                Console.WriteLine("Inserire un numero positivo di gettoni");
            else
                GettoniPresenti += gettoni;
        }

        public void SelezionaProgramma(int numeroProgramma)
        {
            ProgrammaSelezionato = ProgrammiDisponibili.Find(p =>  p.Numero == numeroProgramma);
            if(ProgrammaSelezionato == null)
                Console.WriteLine("Nessun programma trovato");
        }
        public virtual void AvviaProgramma()
        {
            if (ProgrammaSelezionato == null)
                Console.WriteLine("Impossibile far partire la macchina senza aver selezionato un programma");
            else if(Aperta)
                Console.WriteLine("Impossibile far partire la macchina se lo sportello è aperto");
            else if (GettoniPresenti < ProgrammaSelezionato.Gettoni)
                Console.WriteLine($"Solo {GettoniPresenti} gettoni inseriti. Gettoni richiesti: {ProgrammaSelezionato.Gettoni}");
            else
            {
                InFunzione = true;
                TempoRimanenteFineProgrammaMinuti = ProgrammaSelezionato.DurataMinuti;
                GettoniPresenti -= ProgrammaSelezionato.Gettoni;
            }

        }
        public void FermaProgramma() => InFunzione = false;
    }
}
