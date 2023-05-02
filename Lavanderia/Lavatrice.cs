using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia
{
    public class Lavatrice : Macchina
    {
        private int QuantitàMassimaDetersivoMl = 1000;
        private int QuantitàMassimaAmmorbidenteMl = 500;
        public int DetersivoPresenteMl { get; set; }
        public int AmmorbidentePresenteMl { get; set; }

        public Lavatrice() 
        {
            DetersivoPresenteMl = Helper.ReturnRandomNumber(0, QuantitàMassimaDetersivoMl);
            AmmorbidentePresenteMl = Helper.ReturnRandomNumber(0, QuantitàMassimaAmmorbidenteMl);
            ProgrammiDisponibili = new List<Programma>()
            {
                new Programma(1,"Rinfrescante", 20, 5, 25, 20),
                new Programma(2, "Rinnovante", 40, 10, 50, 40),
                new Programma(3, "Sgrassante", 60, 15, 100, 60)
            };
        }

        public override void AvviaProgramma()
        {
            if (ProgrammaSelezionato == null)
                Console.WriteLine("Impossibile far partire la macchina senza aver selezionato un programma");
            else if (Aperta)
                Console.WriteLine("Impossibile far partire la macchina se lo sportello è aperto");
            else if (GettoniPresenti < ProgrammaSelezionato.Gettoni)
                Console.WriteLine($"Solo {GettoniPresenti} gettoni inseriti. Gettoni richiesti: {ProgrammaSelezionato.Gettoni}");
            else if (DetersivoPresenteMl < ProgrammaSelezionato.ConsumoDetersivoMl)
                Console.WriteLine($"Solo {DetersivoPresenteMl} ml di detersivo presenti. Detersivo richiesto: {ProgrammaSelezionato.ConsumoDetersivoMl} ml");
            else if (AmmorbidentePresenteMl < ProgrammaSelezionato.ConsumoAmmorbidenteMl) ;
            else
            {
                InFunzione = true;
                TempoRimanenteFineProgrammaMinuti = ProgrammaSelezionato.DurataMinuti;
                GettoniPresenti -= ProgrammaSelezionato.Gettoni;
                DetersivoPresenteMl -= ProgrammaSelezionato.ConsumoDetersivoMl;
                AmmorbidentePresenteMl -= ProgrammaSelezionato.ConsumoAmmorbidenteMl;
            }
        }

        public void RicaricaDetersivo(int quantitàMl)
        {
            if(DetersivoPresenteMl + quantitàMl > QuantitàMassimaDetersivoMl)
                Console.WriteLine($"Hai aggiunto troppo detersivo. Quantità massima che puoi aggiungere: {QuantitàMassimaDetersivoMl - DetersivoPresenteMl} ml");
            else
                DetersivoPresenteMl += quantitàMl;
        }

        public void RicaricaAmmorbidente(int quantitàMl)
        {
            if(AmmorbidentePresenteMl + quantitàMl > QuantitàMassimaAmmorbidenteMl)
                Console.WriteLine($"Hai aggiunto troppo ammorbidente. Quantità massima che puoi aggiungere: {QuantitàMassimaAmmorbidenteMl - AmmorbidentePresenteMl} ml");
            else
                AmmorbidentePresenteMl += quantitàMl;
        }
    }
}
