using ConsoleTables;

namespace Lavanderia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keep = true;
            Lavanderia lavanderia = new();
            while (keep)
            {
                Console.WriteLine("Stato lavanderia");
                ConsoleTable tableLavanderia = new("Numero", "Tipo", "Gettoni", "Aperta", "In Funzione", "Programma", "Tempo Rimanente", "Detersivo", "Ammorbidente");
                foreach (KeyValuePair<int, Macchina> m in lavanderia.Macchine)
                {
                    int detersivo = m.Value is Lavatrice l ? l.DetersivoPresenteMl : 0;
                    int ammorbidente = m.Value is Lavatrice la ? la.AmmorbidentePresenteMl : 0;
                    string programma = m.Value.ProgrammaSelezionato == null ? "" : m.Value.ProgrammaSelezionato.Nome;
                    tableLavanderia.AddRow(m.Key, 
                        m.Value.GetType().Name, 
                        m.Value.GettoniPresenti, 
                        m.Value.Aperta, 
                        m.Value.InFunzione, 
                        programma,
                        m.Value.TempoRimanenteFineProgrammaMinuti,
                        detersivo,
                        ammorbidente);
                };
                tableLavanderia.Write(Format.Alternative);
                Console.WriteLine("Lista di comandi disponibili:");
                Console.WriteLine("apri <numero_macchina_> | Apre lo sportello della macchina\n" +
                    "chiudi <numero_macchina> | Chiude lo sportello della macchina\n" +
                    "gettoni <numero_macchina> <numero_gettoni> | inserisce i gettoni specificati nella macchina specificata\n" +
                    "lista <numero_macchina> | visualizza l'elenco dei programmi della macchina specificata\n" +
                    "programma <numero_macchina> <numero_programma> | imposta il programma indicato nella macchina indicata\n" +
                    "avvia <numero_macchina> | avvia la macchina indicata\n" +
                    "ferma <numero_macchina> | ferma la macchina indicata\n" +
                    "detersivo <numero_macchina> <quantità> | aggiunge il detersivo nella macchina indicata\n" +
                    "ammorbidente <numero_macchina> <quantità> | aggiunge l'ammorbidente nella macchina indicata\n" +
                    "esci | termina il programma");
                string input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Inserire un comando valido con la seguente sintassi: <comando> <numero_macchina> <altro_parametro>");
                    continue;
                }
                var (comando, n_macchina, altro_parametro) = Helper.SplitInputString(input);
                switch(comando)
                {
                    case "apri":
                        lavanderia.Macchine[n_macchina].ApriSportello();
                        break;

                    case "chiudi":
                        lavanderia.Macchine[n_macchina].ChiudiSportello();
                        break;

                    case "gettoni":
                        lavanderia.Macchine[n_macchina].InserisciGettoni(altro_parametro);
                        break;

                    case "lista":
                        Console.WriteLine($"Lista programmi macchina #{n_macchina}");
                        ConsoleTable tableProgrammi = new ("Numero programma", "Nome programma", "Durata", "Gettoni", "Consumo detersivo", "Consumo ammorbidente");
                        foreach(Programma p in lavanderia.Macchine[n_macchina].ProgrammiDisponibili)
                            tableProgrammi.AddRow(p.Numero, p.Nome, p.DurataMinuti, p.Gettoni, p.ConsumoDetersivoMl, p.ConsumoAmmorbidenteMl);
                        tableProgrammi.Write(Format.Alternative);
                        break;

                    case "programma":
                        lavanderia.Macchine[n_macchina].SelezionaProgramma(altro_parametro);
                        break;

                    case "avvia":
                        lavanderia.Macchine[n_macchina].AvviaProgramma();
                        break;

                    case "ferma":
                        lavanderia.Macchine[n_macchina].FermaProgramma();
                        break;

                    case "detersivo":
                        if (lavanderia.Macchine[n_macchina] is Lavatrice l)
                            l.RicaricaDetersivo(altro_parametro);
                        else
                            Console.WriteLine("Comando non supportato");
                        break;

                    case "ammorbidente":
                        if (lavanderia.Macchine[n_macchina] is Lavatrice la)
                            la.RicaricaAmmorbidente(altro_parametro);
                        else
                            Console.WriteLine("Comando non supportato");
                        break;

                    case "esci":
                        Console.WriteLine("Alla prossima!");
                        keep = false;
                        break;
                }
            }

        }
    }
}