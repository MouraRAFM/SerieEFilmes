

using SerieEFilmes;


List<Serie> ObjetoListarSeries = new List<Serie>();
List<Filme> objetoListarFilmes = new List<Filme>();
List<Epsodio> ObjetoListaEpisodio = new List<Epsodio>();
Serie ObjetoSerie = new Serie();
Filme ObjetoFilme = new Filme();
ConsoleKey escolha;

 
  
exibirTelaInicial();

void exibirTelaInicial()
{

    layoutDEV();

    //layoutTelaInicial
    Console.WriteLine("                                   C# CONSOLE");
    Console.WriteLine("\n                      ==================================");
    Console.WriteLine("                          ______              ________");
    Console.WriteLine("                         |             //    /");
    Console.WriteLine("                         |____        //    /_____");
    Console.WriteLine("                         |           //          / ");
    Console.WriteLine("                         | ilmes    //     _____/ éries");
    Console.WriteLine("                       ================================");
    Console.WriteLine();



    escolha = ConsoleKey.Help;

    while (escolha != ConsoleKey.Applications)
    {
        Console.Write("\rPARA FILMES ESCOLHA (1) / PARA SÉRIES ESCOLHA (2) / PARA SAIR ESCOLHA (0) : ");
        escolha = Console.ReadKey().Key;

        if (escolha == ConsoleKey.D0 || escolha == ConsoleKey.NumPad0)
        {
            Environment.Exit(0);
        }
        else if (escolha == ConsoleKey.D1 || escolha == ConsoleKey.NumPad1)
        {
            layoutDEV();
            ObjetoFilme.LayoutFilmes(objetoListarFilmes,ObjetoFilme);
            exibirTelaInicial();

        }
        else if (escolha == ConsoleKey.D2 || escolha == ConsoleKey.NumPad2)
        {
            layoutDEV();
            ObjetoSerie.LayoutSeries(ObjetoListarSeries, ObjetoSerie, ObjetoListaEpisodio, 1);
            exibirTelaInicial();


        }

    }




}

void layoutDEV()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("************SIMULADOR CADASTRO E NAVEGAÇÂO DE FILMES E SÉRIES***********");
    Console.WriteLine("                     ***********Versão 1.0**********");
    Console.WriteLine("                         **Dev: Ronaldo Almeida**");
    Console.WriteLine("                   GitHub: https://github.com/mourarafm");
    Console.WriteLine("                    Email: Ronaldo.A.F.Moura@Gmail.com");
    Console.WriteLine("              APLICANDO CONHECIMENTOS POO .net C# FULL-STACK");
    Console.WriteLine("************************************************************************");
    Console.ResetColor();

}




/*  while (Console.ReadKey().Key != ConsoleKey.S)
 {
     Console.WriteLine("SERIE: " + ObjetoSerie._Serie);
     Console.WriteLine("DESCRIÇÂO:" + ObjetoSerie._Sinops);
     Console.WriteLine("Nº EPSODIOS:" + ObjetoSerie._Epsodio);
     Console.WriteLine("Nº TEMPORADAS:" + ObjetoSerie._Temporada);
     Console.WriteLine("ANO:" + ObjetoSerie._Ano);
     Console.WriteLine("GENERO:" + ObjetoSerie._Genero);
     Console.WriteLine("\n****Exibir temporadas****");
     Console.WriteLine("APERTE NUMERO DA TEMPORADA QUE DESEJA EXIBIR");
     Console.WriteLine("TEMPORADAS DISPONIVEIS: " + ObjetoSerie._Temporada);

     int escolha = Int32.Parse(Console.ReadLine());

     if (escolha > 0 && escolha <= ObjetoSerie._Temporada)
     {
         ObjetoSerie.Select(ObjetoListarSeries,ObjetoSerie,escolha);
     }


 }
*/





